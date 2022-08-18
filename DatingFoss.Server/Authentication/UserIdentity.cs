using DatingFoss.Domain;

namespace DatingFoss.Server.Authentication;

public class UserIdentity
{
    public UserIdentity(string userName, RSAPublicKey publicKey)
    {
        Username = userName;
        PublicKey = publicKey;
    }

    public string Username { get; }
    public RSAPublicKey PublicKey { get; }
}
