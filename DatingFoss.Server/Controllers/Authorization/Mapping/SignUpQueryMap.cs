using AutoMapper;
using DatingFoss.Application.Authorization.Requests;
using DatingFoss.Application.Authorization.Responses;
using DatingFoss.Server.Controllers.Authorization.Queries;
using DatingFoss.Server.Controllers.Authorization.Responses;

namespace DatingFoss.Server.Controllers.Authorization.Mapping;

public class SignUpQueryMap : Profile
{
    public SignUpQueryMap()
    {
        CreateMap<SignUpQuery, SignUpRequest>();
        CreateMap<SignupResponse, SignUpResponseDTO>();
    }
}
