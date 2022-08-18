using DatingFoss.Server.Controllers.Authorization.Responses;
using DatingFoss.Server.DTOs;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DatingFoss.Server.Controllers.Authorization.Queries;

public record SignUpQuery : IRequest<SignUpResponseDTO>
{
    [Required]
    public string? Username { get; init; }

    [Required]
    public RSAPublicKeyDTO? PublicKey { get; init; }
}