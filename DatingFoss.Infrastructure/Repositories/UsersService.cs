using DatingFoss.Application.Repositories.Abstractions;
using DatingFoss.Application.Repositories.Exceptions;
using DatingFoss.Domain;
using Microsoft.EntityFrameworkCore;

namespace DatingFoss.Infrastructure.Repositories;
public class UsersService : IUsersService
{
    // Initialization
    public UsersService(IQueryableCrud<User> usersCrud)
    {
        Crud = usersCrud;
    }


    // Properties
    public IQueryableCrud<User> Crud { get; }


    // Core
    public async Task<bool> Exists(string? username, CancellationToken cancellationToken)
    {
        return await FindByUsernameQueryable(username).AnyAsync(cancellationToken: cancellationToken);
    }

    public async Task<User> FindByUsername(string username, CancellationToken cancellationToken)
    {
        var user = await FindByUsernameQueryable(username).FirstOrDefaultAsync(cancellationToken);
        _ = user ?? throw new UserNotFoundException(username);

        return user;
    }

    public IQueryable<User> FindByUsernameQueryable(string? username)
        => Crud.Entities.Where(user => user.Username == username);

    public async Task<RSAPublicKey> GetPublicKey(string username, CancellationToken cancellationToken)
    {
        return await FindByUsernameQueryable(username)
            .Select(u => u.PublicKey)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken)
            ?? throw new UserNotFoundException(username);
    }
}
