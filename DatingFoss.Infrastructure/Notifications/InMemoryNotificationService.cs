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

    public async Task<INotification> Pull(string username, CancellationToken cancellationToken)
    {
        var queue = _notificationQueuesByUsername.GetValueOrCreate(username);
        var notification = await queue.Get(cancellationToken);
        return notification;
    }

    public async Task Push<T>(string username, Notification<T> notification, CancellationToken cancellationToken)
    {
        var queue = _notificationQueuesByUsername.GetValueOrCreate(username);
        await queue.NotifyNew(notification, cancellationToken);
        await Task.CompletedTask;
    }
}
