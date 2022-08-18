using AutoMapper;
using DatingFoss.Application.Messages.Requests;
using DatingFoss.Application.Messages.Responses;
using DatingFoss.Server.Controllers.Messages.ActionsResponses;
using DatingFoss.Server.Controllers.Messages.Queries;
using DatingFoss.Server.Controllers.Messages.Responses;
using DatingFoss.Server.DTOs;

namespace DatingFoss.Server.Controllers.Messages.Mapping;

public class MessageMap : Profile
{
    public MessageMap()
    {
        CreateMap<SendMessageQuery, SendMessageRequest>();
        CreateMap<SendMessageResponse, SendMessageResponseDTO>();
        CreateMap<MessageDTO, MessagesResponse>();
    }
}
