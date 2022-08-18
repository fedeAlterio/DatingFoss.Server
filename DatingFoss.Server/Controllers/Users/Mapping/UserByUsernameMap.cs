﻿using AutoMapper;
using DatingFoss.Application.Users.Requests;
using DatingFoss.Application.Users.Responses;
using DatingFoss.Server.Controllers.Users.Queries;
using DatingFoss.Server.Controllers.Users.Responses;

namespace DatingFoss.Server.Controllers.Users.Mapping;

public class UserByUsernameMap : Profile
{
    public UserByUsernameMap()
    {
        CreateMap<UserByUsernameQuery, UserByUsernameRequest>();
        CreateMap<UserByUsernameResponse, UserByUsernameResponseDTO>();
    }
}
