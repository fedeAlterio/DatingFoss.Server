using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DatingFoss.Server.DTOs;

public class UserPublicInfoDTO
{
    [Range(0,1)]
    public double? Sex { get; init; }

    [JsonPropertyName("location")]
    public PointDTO? Position { get; init; }


    [StringLength(maximumLength: 500)]
    public string? Bio { get; init; }


    [JsonPropertyName("textInfo")]
    public Dictionary<string, string>? TextualInfo { get; init; }


    [JsonPropertyName("boolInfo")]
    public Dictionary<string, bool>? BooleanInfo { get; init; }


    [JsonPropertyName("dateInfo")]
    public Dictionary<string, DateTime>? TemporalInfo { get; init; }
    public List<string>? Interests { get; init; }
    public List<string>? Pictures { get; init; }
    public ValueRangeDTO<double>? Searching { get; init; }
}
