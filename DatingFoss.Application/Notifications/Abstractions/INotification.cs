using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Application.Notifications.Abstractions;
public interface INotification
{
    NotificationType Type { get; }
    object? Content { get; }
}

