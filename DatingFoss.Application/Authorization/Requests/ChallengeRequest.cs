using DatingFoss.Application.Authorization.Responses;
using MediatR;

namespace DatingFoss.Application.Authorization.Requests;

public class ChallengeRequest : IRequest<ChallengeResponse>
{
    public string? Username { get; init; }
}
