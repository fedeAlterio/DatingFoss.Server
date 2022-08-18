using DatingFoss.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Infrastructure.Notifications;
public class UpdateQueue<T>
{
    // Private fields
    private readonly SemaphoreSlim _ss = new(1);
    private readonly IList<TaskCompletionWrapper<T>> _taskSource = new List<TaskCompletionWrapper<T>> { new TaskCompletionWrapper<T>() };



    // Proeprties
    public bool IsWaitingForUpdate { get; set; } = false;
    public long VersionFetched { get; private set; }



    // Public Methods
    public async Task<T> Get(CancellationToken cancellationToken)
    {
        TaskCompletionWrapper<T> taskWrapper;
        using (await _ss.WaitAsyncScoped(cancellationToken))
        {
            taskWrapper = _taskSource[0];
        }

        var retTask = taskWrapper.TaskCompletionSource.Task;
        await Task.WhenAny(retTask, cancellationToken.WaitUntilCancellation());

        if (!retTask.IsCompleted)
            throw new OperationCanceledException();

        var ret = retTask.Result;
        using var _ = await _ss.WaitAsyncScoped(cancellationToken);

        taskWrapper.Used = true;
        CheckTaskCompleted();
        if (VersionFetched == long.MaxValue)
            VersionFetched = 0;
        else
            VersionFetched++;
        return ret;
    }

    public async Task NotifyNew(T t, CancellationToken cancellationToken)
    {
        using var _ = await _ss.WaitAsyncScoped(cancellationToken);
        if (_taskSource.Last().Notified)
            _taskSource.Add(new TaskCompletionWrapper<T>());
        var last = _taskSource.Last();
        last.Notified = true;
        last.TaskCompletionSource.SetResult(t);
        CheckTaskCompleted();
    }



    // Utils
    private void CheckTaskCompleted()
    {
        var taskWrapper = _taskSource[0];
        if (taskWrapper.Notified && taskWrapper.Used)
        {
            _taskSource.RemoveAt(0);
            if (!_taskSource.Any())
                _taskSource.Add(new TaskCompletionWrapper<T>());
        }
    }
}

public class TaskCompletionWrapper<T>
{
    public TaskCompletionSource<T> TaskCompletionSource { get; } = new TaskCompletionSource<T>();
    public bool Used { get; set; }
    public bool Notified { get; set; }
}

