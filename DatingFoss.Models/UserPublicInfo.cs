using NetTopologySuite.Geometries;

namespace DatingFoss.Domain;
public record UserPublicInfo
{
    public double? Sex { get; init; }
    public Point? Position { get; init; }
    public string? Bio { get; init; }
    public UserInfoDictionary<string>? TextualInfo { get; init; } = new();
    public UserInfoDictionary<bool>? BooleanInfo { get; init; } = new();
    public UserInfoDictionary<DateTime>? TemporalInfo { get; init; } = new();
    public List<string> Interests { get; init; } = new();
    public List<string> Pictures { get; init; } = new();
    public ValueRange<double>? Searching { get; init; }
}
