using DatingFoss.Server.Controllers.Discover.DTOs;
using DatingFoss.Server.Controllers.Discover.Responses;
using MediatR;

namespace DatingFoss.Server.Controllers.Discover.Queries;

public class PossiblePartnersQuery : IRequest<PossiblePartnersResponseDTO>
{
    public PossiblePartnersQueryParametersDTO? Parameters { get; init; }
}
