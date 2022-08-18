using DatingFoss.Server.DTOs;

namespace DatingFoss.Server.Controllers.Discover.Responses;

public class PossiblePartnersResponseDTO
{
    public IList<UserDTO>? PossiblePartners { get; init; }
}
