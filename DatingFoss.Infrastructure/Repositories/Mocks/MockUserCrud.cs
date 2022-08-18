using DatingFoss.Domain;
using DatingFoss.Domain.Exceptions;
using DatingFoss.Infrastructure.Encryption;
using System.Security.Cryptography;

namespace DatingFoss.Infrastructure.Repositories.Mocks;
public class MockUserCrud : MockCrud<User>
{
    public MockUserCrud()
    {

    }

    private static User CreateUser(string username)
    {
        var exponentBase64 = "AQAB";
        var modulusBase64 = "ltDexlcJC6btMxYeEmarCra1058+puTBILG3s9bVbavvEVEtFo1BPjkM9YRXbHPg36aWh6Y308gPTyE91Z/yvDMrPxIrGdIcDF9kTlPBq206V9Sw6nXuLS9bPvA6zAZbD5HCpHD50nfiWRunycvNcEp64aFCSSvRPT6XqVlW9ivjq6jlrPVA9uj1LwGRFjeZVTF8kypz1TulZb6J0jy3sovYBqHgN+ynVY5gOpIV4NJBnAx+N/y0jm/UMTpQg9uADJKi8diY4N2OrnDC85sSvNwUNvHK/Gv5dxku5SERUhkUro3cxMd+wo/ZlldgTWFYPTQlzY6fnKKx1dA1f7vjJw==";
        var key = new EncryptionService().RSAParametersFromExponentAndModulus(exponentBase64, modulusBase64);

        var user = new User
        {
            Username = username,
            PublicKey = new(key),
            PrivateInfo = new(),
            PublicInfo = new()
        };
        return user;
    }

    public override Task<User> Update(User entity, CancellationToken cancellationToken)
    {
        lock (_locker)
        {
            var toRemove = _entities.FirstOrDefault(user => user.Username == entity.Username);
            if (toRemove is null)
                throw new DatingFossException($"User not found");

            _entities.Remove(toRemove);
            _entities.Add(entity);

            return Task.FromResult(entity);
        }
    }
}
