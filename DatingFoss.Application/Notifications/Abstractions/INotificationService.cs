using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Application.Notifications.Abstractions;
public interface INotificationService
{
    Task Push<T>(string username, Notification<T> notification, CancellationToken cancellationToken);
    Task<INotification> Pull(string username, CancellationToken cancellationToken);
}
