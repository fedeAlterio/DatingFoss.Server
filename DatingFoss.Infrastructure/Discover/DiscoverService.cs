using DatingFoss.Application.Discover.Abstractions;
using DatingFoss.Application.Discover.Models;
using DatingFoss.Application.Repositories.Abstractions;
using DatingFoss.Domain;
using Microsoft.EntityFrameworkCore;

namespace DatingFoss.Infrastructure.Discover;
public class DiscoverService : IDiscoverService
{
    private readonly ICrud<User> _userCrud;
    private readonly IQueryable<User> _users;

    public DiscoverService(ICrud<User> userCrud, IQueryable<User> users)
    {
        _userCrud = userCrud;
        _users = users;
    }

    public async Task<List<User>> FindPossiblePartners(PossiblePartnersQueryParameters parameters)
    {
        var possiblePartners = from currentUser in _users
                               where currentUser.Username == parameters.Username
                               from user in _users
                               where user.Username != parameters.Username
                               where !parameters.ExcludedUsernames!.Contains(user.Username!)
                               let userSex = user.PublicInfo!.Sex
                               let currentUserSearching = currentUser.PublicInfo!.Searching
                               where currentUserSearching == null || userSex == null
                                || (currentUserSearching.Start <= userSex && userSex <= currentUserSearching.End)
                               select user;

        return await possiblePartners.Take(parameters.ResultsLimit).ToListAsync();
    }
}
