using DatingFoss.Server.DTOs;
using System.ComponentModel.DataAnnotations;

namespace DatingFoss.Server.Controllers.Users.DTOs;

public class UpdateUserDataDTO
{
    [Required]
    public UserPublicInfoDTO? PublicInfo { get; init; }

    [Required]
    public UserPrivateInfoDTO? PrivateInfo { get; init; }
}
