using AutoMapper;
using DatingFoss.Application.Users.Requests;
using DatingFoss.Application.Users.Responses;
using DatingFoss.Server.Controllers.Users.Queries;
using DatingFoss.Server.Controllers.Users.Responses;

namespace DatingFoss.Server.Controllers.Users.Mapping;

public class SymmetricKeysMap : Profile
{
    public SymmetricKeysMap()
    {
        CreateMap<PostSymmetricKeysQuery, PostSymmetricKeysRequest>();
        CreateMap<PostSymmetricKeysResponse, PostSymmetricKeysResponseDTO>();

        CreateMap<GetSymmetricKeysQuery, GetSymmetricKeysRequest>();
        CreateMap<GetSymmetricKeysResponse, GetSymmetricKeysResponseDTO>();
    }
}
