using DatingFoss.Server.Controllers.Notifications.Attributes;

namespace DatingFoss.Server.Controllers.Notifications.Contents;

[NotificationContentDTO]
public class LikeMessageNotificationContentDTO
{    
    public string? Content { get; init; }
}
