using AutoMapper;
using DatingFoss.Application.Messages.Requests;
using DatingFoss.Application.Messages.Responses;
using DatingFoss.Server.Controllers.Messages.Queries;
using DatingFoss.Server.Controllers.Messages.Responses;

namespace DatingFoss.Server.Controllers.Messages.Mapping;

public class GetMessagesMap : Profile
{
    public GetMessagesMap()
    {
        CreateMap<GetMessagesQuery, GetMessagesRequest>();
        CreateMap<GetMessagesResponse, GetMessagesResponseDTO>();
    }
}
