using AutoMapper;
using DatingFoss.Application.Users.Requests;
using DatingFoss.Application.Users.Responses;
using DatingFoss.Domain;
using DatingFoss.Server.Controllers.Users.DTOs;
using DatingFoss.Server.Controllers.Users.Queries;
using DatingFoss.Server.Controllers.Users.Responses;

namespace DatingFoss.Server.Controllers.Users.Mapping;

public class UpdateUserDataMap : Profile
{
    public UpdateUserDataMap()
    {
        CreateMap<UpdateUserDataDTO, User>();
        CreateMap<UpdateUserDataQuery, UpdateUserDataRequest>();
        CreateMap<UpdateUserDataResponse, UpdateUserDataResponseDTO>();
    }
}
