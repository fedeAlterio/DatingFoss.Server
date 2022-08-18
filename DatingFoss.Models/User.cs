using System.ComponentModel.DataAnnotations;

namespace DatingFoss.Domain;
public record User
{
    [Key]
    public string? Username { get; init; }
    public RSAPublicKey? PublicKey { get; init; }
    public UserPublicInfo? PublicInfo { get; init; } = new();
    public UserPrivateInfo? PrivateInfo { get; init; } = new();
    public string? SymmetricKeys { get; init; }
    public string? LikedUsernames { get; init; }
}
