using DatingFoss.Application.Notifications.Abstractions;
using DatingFoss.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Application.Notifications.Extensions;
public static class INotificationServiceExtensions
{
    public static async Task PushMessage(this INotificationService @this, Message message, CancellationToken cancellationToken)
    {
        var username = message.ToUsername!;
        var notification = new Notification<Message>
        {
            Type = NotificationType.Message,
            Content = message
        };

        await @this.Push(username, notification, cancellationToken);
    }

    public static async Task PushLikeMessage(this INotificationService @this, LikeMessage likeMessage, CancellationToken cancellationToken)
    {
        var username = likeMessage.ToUsername!;
        var notification = new Notification<LikeMessage>
        {
            Type = NotificationType.LikeMessage,
            Content = likeMessage
        };

        await @this.Push(username, notification, cancellationToken);
    }
}
