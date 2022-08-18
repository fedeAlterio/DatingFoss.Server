namespace DatingFoss.Application.Discover.Models;
public class PossiblePartnersQueryParameters
{
    public string? Username { get; init; }
    public int ResultsLimit { get; init; }
    public IList<string>? ExcludedUsernames { get; init; }
}
