using DatingFoss.Application.Notifications.Abstractions;
using DatingFoss.Server.DTOs;
using System.Collections.Generic;

namespace DatingFoss.Server.Controllers.Notifications.Responses;

public class FetchNotificationsResponseDTO
{
    public IReadOnlyList<NotificationDTO>? Notifications { get; init; }
}
