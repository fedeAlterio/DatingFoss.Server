using DatingFoss.Server.Controllers.Notifications.Responses;
using MediatR;

namespace DatingFoss.Server.Controllers.Notifications.Queries;

public class FetchNotificationsQuery : IRequest<FetchNotificationsResponseDTO>
{
    public string? Username { get; init; }
}
