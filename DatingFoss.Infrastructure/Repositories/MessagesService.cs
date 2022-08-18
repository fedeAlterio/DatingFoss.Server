using DatingFoss.Application.Messages.Abstractions;
using DatingFoss.Application.Messages.Requests;
using DatingFoss.Application.Repositories.Abstractions;
using DatingFoss.Domain;
using DatingFoss.Infrastructure.Extensions;
using DatingFoss.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Infrastructure.Repositories;
public class MessagesService : IMessagesService
{
    private readonly IQueryableCrud<Message> _messageCrud;
    private readonly SemaphoreSlim _ss = new(1);
    private TaskCompletionSource _messageCompletionSource = new();


    private bool WaitingForNewMessage { get; set; }

    public MessagesService(IQueryableCrud<Message> messageCrud)
    {
        _messageCrud = messageCrud;
    }

    public async Task<List<Message>> PullMessages(GetMessagesRequest request, bool blockUntilUpdates, CancellationToken cancellationToken)
    {
        Task? longPollingTaskIfNoMessagesAvailable = null;
        using (await _ss.WaitAsyncScoped())
        {
            var query = _messageCrud.Entities;
            if (request.FromUsername is not null)
                query = query.Where(x => x.FromUsername == request.FromUsername);

            if (request.ToUsername is not null)
                query = query.Where(x => x.ToUsername == request.ToUsername);

            var messages = await query
                .Take(request.MaximumResultsCount)
                .ToListAsync(cancellationToken: cancellationToken);

            await _messageCrud.Delete(messages, cancellationToken);
            if (messages.Any())
                return messages;        
            
            WaitingForNewMessage = true;
            longPollingTaskIfNoMessagesAvailable = WaitForNewMessage(cancellationToken);
        }

        await longPollingTaskIfNoMessagesAvailable!;
        return await PullMessages(request, blockUntilUpdates, cancellationToken);
    }

    public async Task SendMessage(Message message, CancellationToken cancellationToken)
    {
        using var _ = await _ss.WaitAsyncScoped();
        message.SentDate = DateTime.UtcNow;
        await _messageCrud.Add(message, cancellationToken);
        if (WaitingForNewMessage)
            NotifyNewMessage(message);
    }


    // Utils
    private Task WaitForNewMessage(CancellationToken cancellationToken)
    {
        CreateNewTcsIfCompleted();
        var tcs = _messageCompletionSource;
        cancellationToken.Register(() => tcs.TrySetCanceled());
        var task = tcs.Task;
        return task;
    }

    private void NotifyNewMessage(Message message)
    {
        WaitingForNewMessage = false;
        var tcs = _messageCompletionSource;
        _messageCompletionSource = new();
        tcs.SetResult();
    }

    private void CreateNewTcsIfCompleted()
    {
        if (_messageCompletionSource.Task.IsCompleted)
            _messageCompletionSource = new();
    }
}
