using DatingFoss.Application.Authorization.Responses;
using MediatR;

namespace DatingFoss.Application.Authorization.Requests;
public class LoginRequest : IRequest<LoginResponse>
{
    public Token? Token { get; init; }
    public string? DataSignedFromClient { get; init; }
}
