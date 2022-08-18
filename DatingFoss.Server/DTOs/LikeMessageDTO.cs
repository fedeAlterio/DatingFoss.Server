using System.ComponentModel.DataAnnotations;

namespace DatingFoss.Server.DTOs;

public class LikeMessageDTO
{
    [Required]
    public string? ToUsername { get; init; }

    [Required]
    public string? Content { get; init; }
}
