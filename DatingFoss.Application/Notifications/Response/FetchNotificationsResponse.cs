using DatingFoss.Application.Notifications.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Application.Notifications.Response;
public class FetchNotificationsResponse
{
    public IReadOnlyList<INotification>? Notifications { get; init; }
}
