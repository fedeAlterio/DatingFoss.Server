using AutoMapper;
using AutoMapper.Internal;
using DatingFoss.Application.Notifications.Abstractions;
using DatingFoss.Server.Controllers.Notifications.Mapping.ValueResolvers;
using DatingFoss.Server.DTOs;

namespace DatingFoss.Server.Mapping;

public class NotificationMap : Profile
{
    public NotificationMap()
    {
        CreateMap<INotification, NotificationDTO>()
            .ForMember(x => x.Content, x => x.MapFrom<NotificationContentResolver>());
    }
}
