using AutoMapper;
using DatingFoss.Domain;
using DatingFoss.Server.DTOs;

namespace DatingFoss.Server.Mapping;

public class RSAKeyMap : Profile
{
    public RSAKeyMap()
    {
        CreateMap<RSAPublicKey, RSAPublicKeyDTO>();
        CreateMap<RSAPublicKeyDTO, RSAPublicKey>();
    }
}
