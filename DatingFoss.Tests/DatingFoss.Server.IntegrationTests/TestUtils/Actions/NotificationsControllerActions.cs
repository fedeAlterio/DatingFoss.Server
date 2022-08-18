using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DatingFoss.Application.Notifications;
using DatingFoss.Application.Notifications.Abstractions;
using DatingFoss.Domain;
using DatingFoss.Server.DTOs;
using DatingFoss.Server.IntegrationTests.TestUtils.Extensions;
using DatingFoss.Server.IntegrationTests.TestUtils.Routes;

namespace DatingFoss.Server.IntegrationTests.TestUtils.Actions
{
    public static class NotificationsControllerActions
    {
        public static async Task<IList<NotificationDTO>> Fetch(this HttpClient @this)
        {
            var url = NotificationsRoutes.Fetch;
            var notifications = await @this.GetAndParse<IList<NotificationDTO>>(url);
            return notifications;
        }

        public static async IAsyncEnumerable<INotification> Notifications(this HttpClient @this)
        {
            while (true)
            {
                var notifications = await @this.Fetch();
                foreach(var notification in notifications)
                    yield return ParseNotification(notification);
            }
        }


        private static INotification ParseNotification(NotificationDTO notification)
        {
            if (notification.Type == NotificationType.LikeMessage)
            {
                var contentJson = notification.Content!.ToString()!;
                var serializationOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var likeMessage = JsonSerializer.Deserialize<LikeMessage>(contentJson, serializationOptions);
                return new Notification<LikeMessage> { Content = likeMessage, Type = NotificationType.LikeMessage };
            }

            throw new NotImplementedException();
        }

    }
}
