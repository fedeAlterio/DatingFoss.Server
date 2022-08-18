using DatingFoss.Application.Users.Responses;
using MediatR;

namespace DatingFoss.Application.Users.Requests;
public class UserByUsernameRequest : IRequest<UserByUsernameResponse>
{
    public string? Username { get; init; }
}
