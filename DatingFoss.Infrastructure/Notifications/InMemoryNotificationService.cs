using DatingFoss.Application.Notifications;
using DatingFoss.Application.Notifications.Abstractions;
using DatingFoss.Infrastructure.Extensions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Infrastructure.Notifications;
public class InMemoryNotificationService : INotificationService
{
    private readonly ConcurrentDictionary<string, UpdateQueue<INotification>> _notificationQueuesByUsername = new();
    private readonly SemaphoreSlim _ss = new(1);
    private CancellationTokenSource _tcs = new();    
    public async Task ClearAll(CancellationToken cancellationToken)
    {
        await _ss.WaitAsync();
        var tcs = _tcs;
        _notificationQueuesByUsername.Clear();

        _tcs = new();
        tcs.Cancel();
        tcs.Dispose();

        _ss.Release();        
    }

    public async Task<INotification> Pull(string username, CancellationToken cancellationToken)
    {
        using var tcs = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _tcs.Token);
        cancellationToken = tcs.Token;
        var queue = _notificationQueuesByUsername.GetValueOrCreate(username);        
        var notification = await queue.Get(cancellationToken);
        return notification;
    }

    public async Task Push<T>(string username, Notification<T> notification, CancellationToken cancellationToken)
    {
        using var tcs = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _tcs.Token);
        cancellationToken = tcs.Token;
        var queue = _notificationQueuesByUsername.GetValueOrCreate(username);
        await queue.NotifyNew(notification, cancellationToken);
        await Task.CompletedTask;
    }
}
