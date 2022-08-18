using AutoMapper;
using DatingFoss.Application.Discover.Requests;
using DatingFoss.Server.Controllers.Discover.Queries;
using DatingFoss.Server.Controllers.Discover.Responses;
using DatingFoss.Server.Controllers.QueryHandlers;
using MediatR;

namespace DatingFoss.Server.Controllers.Discover.QueryHandlers;

public class PossiblePartnersQueryHandler : ViewToApplicationRequestHandler<PossiblePartnersQuery, PossiblePartnersRequest, PossiblePartnersResponseDTO>
{
    public PossiblePartnersQueryHandler(IMapper mapper, IMediator mediator) : base(mapper, mediator)
    {
    }
}
