using AutoMapper;
using DatingFoss.Application.Authorization;
using DatingFoss.Server.DTOs;

namespace DatingFoss.Server.Mapping;

public class ChallengeMap : Profile
{
    public ChallengeMap()
    {
        CreateMap<Token, TokenDTO>();
        CreateMap<TokenDTO, Token>();
        CreateMap<Challenge, ChallengeDTO>();
        CreateMap<ChallengeDTO, Challenge>();
    }
}
