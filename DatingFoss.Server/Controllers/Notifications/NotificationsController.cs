using DatingFoss.Application.Notifications.Abstractions;
using DatingFoss.Server.Authentication.Extensions;
using DatingFoss.Server.Controllers.Notifications.Queries;
using DatingFoss.Server.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using INotification = DatingFoss.Application.Notifications.Abstractions.INotification;

namespace DatingFoss.Server.Controllers.Notifications;

[ApiController]
[Route("[Controller]")]
public class NotificationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public NotificationsController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [Route("[Action]")]
    [HttpGet]
    [Authorize]
    public async Task<IEnumerable<NotificationDTO>> Fetch(CancellationToken cancellationToken)
    {
        var query = new FetchNotificationsQuery
        {
            Username = this.GetUserIdentity().Username
        };

        var response = await _mediator.Send(query, cancellationToken);
        return response.Notifications!;
    }
}
