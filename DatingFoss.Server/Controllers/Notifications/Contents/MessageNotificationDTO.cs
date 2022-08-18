using DatingFoss.Server.Controllers.Notifications.Attributes;
using System.Text.Json.Serialization;

namespace DatingFoss.Server.Controllers.Notifications.Models;

[NotificationContentDTO]
public class MessageNotificationContentDTO
{
    public string? From { get; init; }
    public string? Content { get; init; }

    [JsonPropertyName("timestamp")]
    public DateTime? SentDate { get; init; }
}
