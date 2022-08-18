using DatingFoss.Application.Discover.Abstractions;
using DatingFoss.Application.Discover.Requests;
using DatingFoss.Application.Discover.Responses;
using MediatR;

namespace DatingFoss.Application.Discover.RequestsHandlers;
public class PossiblePartnersHandler : IRequestHandler<PossiblePartnersRequest, PossiblePartnersResponse>
{
    private readonly IDiscoverService _discoverService;

    public PossiblePartnersHandler(IDiscoverService discoverService)
    {
        _discoverService = discoverService;
    }

    public async Task<PossiblePartnersResponse> Handle(PossiblePartnersRequest request, CancellationToken cancellationToken)
    {
        var possiblePartners = await _discoverService.FindPossiblePartners(request.Parameters!);
        return new() { PossiblePartners = possiblePartners };
    }
}
