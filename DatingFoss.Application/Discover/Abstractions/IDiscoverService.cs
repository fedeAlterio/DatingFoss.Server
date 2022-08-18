using DatingFoss.Application.Discover.Models;
using DatingFoss.Domain;

namespace DatingFoss.Application.Discover.Abstractions;
public interface IDiscoverService
{
    Task<List<User>> FindPossiblePartners(PossiblePartnersQueryParameters parameters);
}
