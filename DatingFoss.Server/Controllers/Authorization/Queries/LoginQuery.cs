using DatingFoss.Server.Controllers.Authorization.Responses;
using DatingFoss.Server.DTOs;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DatingFoss.Server.Controllers.Authorization.Queries;

public class LoginQuery : IRequest<LoginResponseDTO>
{
    [Required]
    public TokenDTO? Token { get; init; }

    [Required]
    public string? DataSignedFromClient { get; init; }
}
