using DatingFoss.Domain;

namespace DatingFoss.Application.Repositories.Abstractions;
public interface IUsersService
{
    Task<User> FindByUsername(string username, CancellationToken cancellationToken);
    Task<bool> Exists(string? username, CancellationToken cancellationToken);
    Task<RSAPublicKey> GetPublicKey(string username, CancellationToken cancellationToken);
}
