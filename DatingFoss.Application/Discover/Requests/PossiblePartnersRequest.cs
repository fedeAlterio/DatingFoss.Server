using DatingFoss.Application.Discover.Models;
using DatingFoss.Application.Discover.Responses;
using MediatR;

namespace DatingFoss.Application.Discover.Requests;
public class PossiblePartnersRequest : IRequest<PossiblePartnersResponse>
{
    public PossiblePartnersQueryParameters? Parameters { get; init; }
}
