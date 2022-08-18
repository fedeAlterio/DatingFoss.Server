using DatingFoss.Application.Notifications;

namespace DatingFoss.Server.DTOs;

public class NotificationDTO
{
    public NotificationType Type { get; init; }
    public object? Content { get; init; }
}
