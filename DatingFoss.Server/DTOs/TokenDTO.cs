using System.ComponentModel.DataAnnotations;

namespace DatingFoss.Server.DTOs;

public class TokenDTO
{
    [Required]
    public ChallengeDTO? Challenge { get; init; }

    [Required]
    public string? ServerSignedToken { get; init; }
}


