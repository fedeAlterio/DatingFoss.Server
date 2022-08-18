using AutoMapper;
using DatingFoss.Domain;
using DatingFoss.Server.DTOs;

namespace DatingFoss.Server.Mapping;

public class LikeMessageMap : Profile
{
    public LikeMessageMap()
    {
        CreateMap<LikeMessageDTO, LikeMessage>();
    }
}
