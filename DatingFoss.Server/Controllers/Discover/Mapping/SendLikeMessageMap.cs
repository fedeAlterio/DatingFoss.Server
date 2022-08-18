using AutoMapper;
using DatingFoss.Application.Discover.Requests;
using DatingFoss.Application.Discover.Responses;
using DatingFoss.Server.Controllers.Discover.Queries;
using DatingFoss.Server.Controllers.Discover.Responses;

namespace DatingFoss.Server.Controllers.Discover.Mapping;

public class SendLikeMessageMap : Profile
{
    public SendLikeMessageMap()
    {
        CreateMap<SendLikeMessageQuery, SendLikeMessageRequest>();
        CreateMap<SendLikeMessageResponse, SendLikeMessageResponseDTO>();
    }
}
