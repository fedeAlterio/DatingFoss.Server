using AutoMapper;
using DatingFoss.Domain;
using DatingFoss.Server.Controllers.Notifications.Contents;
using DatingFoss.Server.Controllers.Notifications.Models;

namespace DatingFoss.Server.Controllers.Notifications.Mapping;

public class NotificationMap : Profile
{
    public NotificationMap()
    {
        CreateMap<Message, MessageNotificationContentDTO>();
        CreateMap<LikeMessage, LikeMessageNotificationContentDTO>();
    }
}
