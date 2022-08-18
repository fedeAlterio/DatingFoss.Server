using DatingFoss.Application.Notifications.Abstractions;
using DatingFoss.Application.Notifications.Requests;
using DatingFoss.Application.Notifications.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Application.Notifications.Handlers;
public class FetchNotificationsHandler : IRequestHandler<FetchNotificationsRequest, FetchNotificationsResponse>
{
    private readonly INotificationService _notificationService;

    public FetchNotificationsHandler(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }


    public async Task<FetchNotificationsResponse> Handle(FetchNotificationsRequest request, CancellationToken cancellationToken)
    {
        var notification = await _notificationService.Pull(request.Username!, cancellationToken);
        var notifications = new[] { notification };
        return new FetchNotificationsResponse { Notifications = notifications };
    }
}
