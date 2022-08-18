using DatingFoss.Application.Authorization.Responses;
using DatingFoss.Domain;
using MediatR;

namespace DatingFoss.Application.Authorization.Requests;

public record SignUpRequest : IRequest<SignupResponse>
{
    public string? Username { get; init; }
    public RSAPublicKey? PublicKey { get; init; }
}