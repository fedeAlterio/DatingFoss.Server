using AutoMapper;
using DatingFoss.Application.Notifications.Requests;
using DatingFoss.Server.Controllers.Notifications.Queries;
using DatingFoss.Server.Controllers.Notifications.Responses;
using DatingFoss.Server.Controllers.QueryHandlers;
using MediatR;

namespace DatingFoss.Server.Controllers.Notifications.QueriesHandlers;

public class FetchNotificationQueryHandler
    : ViewToApplicationRequestHandler<FetchNotificationsQuery, FetchNotificationsRequest, FetchNotificationsResponseDTO>
{
    public FetchNotificationQueryHandler(IMapper mapper, IMediator mediator) : base(mapper, mediator)
    {
    }
}
