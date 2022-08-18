using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DatingFoss.Server.Controllers.Discover.DTOs;

public record PossiblePartnersQueryParametersDTO
{
    [JsonIgnore]
    public string? Username { get; init; }

    [Range(1, 20)]
    public int ResultsLimit { get; init; }

    public IList<string>? ExcludedUsernames { get; init; }
}
