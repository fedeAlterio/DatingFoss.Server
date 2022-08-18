using AutoMapper;
using DatingFoss.Domain;
using DatingFoss.Server.DTOs;

namespace DatingFoss.Server.Mapping;

public class MessageMap : Profile
{
    public MessageMap()
    {
        CreateMap<Message, MessageDTO>();
        CreateMap<MessageDTO, Message>();
    }
}
