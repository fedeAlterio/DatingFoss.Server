using DatingFoss.Application.Notifications.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Application.Notifications;
public class Notification<T> : INotification
{
    public NotificationType Type { get; init; }
    public T? Content { get; init; }

    #region Covariance workaround
    object? INotification.Content => Content;
    #endregion
}