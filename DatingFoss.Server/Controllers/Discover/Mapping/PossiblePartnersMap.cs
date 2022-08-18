using AutoMapper;
using DatingFoss.Application.Discover.Models;
using DatingFoss.Application.Discover.Requests;
using DatingFoss.Application.Discover.Responses;
using DatingFoss.Server.Controllers.Discover.DTOs;
using DatingFoss.Server.Controllers.Discover.Queries;
using DatingFoss.Server.Controllers.Discover.Responses;

namespace DatingFoss.Server.Controllers.Discover.Mapping;

public class PossiblePartnersMap : Profile
{
    public PossiblePartnersMap()
    {
        CreateMap<PossiblePartnersQuery, PossiblePartnersRequest>();
        CreateMap<PossiblePartnersQueryParametersDTO, PossiblePartnersQueryParameters>();
        CreateMap<PossiblePartnersResponse, PossiblePartnersResponseDTO>();
    }
}
