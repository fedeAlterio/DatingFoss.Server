using System.ComponentModel.DataAnnotations;

namespace DatingFoss.Server.DTOs;

public class ChallengeDTO
{
    [Required]
    public string? DataToSign { get; init; }

    [Required]
    public string? Username { get; init; }

    [Required]
    public DateTime? ExpirationDate { get; init; }
}


