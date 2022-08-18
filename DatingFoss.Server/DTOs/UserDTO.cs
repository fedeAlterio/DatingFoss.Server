using System.ComponentModel.DataAnnotations;

namespace DatingFoss.Server.DTOs;

public class UserDTO
{
    [Required]
    [StringLength(maximumLength: 30, MinimumLength = 5)]
    public string? Username { get; init; }

    [Required]
    public RSAPublicKeyDTO? PublicKey { get; init; }

    [Required]
    public UserPublicInfoDTO? PublicInfo { get; init; }

    [Required]
    public UserPrivateInfoDTO? PrivateInfo { get; init; }
}
