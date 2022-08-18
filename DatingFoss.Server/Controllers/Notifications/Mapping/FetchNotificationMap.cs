using AutoMapper;
using DatingFoss.Application.Notifications.Requests;
using DatingFoss.Application.Notifications.Response;
using DatingFoss.Server.Controllers.Notifications.Queries;
using DatingFoss.Server.Controllers.Notifications.Responses;

namespace DatingFoss.Server.Controllers.Notifications.Mapping;

public class FetchNotificationMap : Profile
{
    public FetchNotificationMap()
    {
        CreateMap<FetchNotificationsQuery, FetchNotificationsRequest>();
        CreateMap<FetchNotificationsResponse, FetchNotificationsResponseDTO>();
    }
}
