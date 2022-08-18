using AutoMapper;
using DatingFoss.Domain;
using DatingFoss.Server.DTOs;

namespace DatingFoss.Server.Controllers.Authorization.Mapping;

public class RSAKeyMap : Profile
{
    public RSAKeyMap()
    {
        CreateMap<RSAPublicKey, RSAPublicKeyDTO>();
    }
}
