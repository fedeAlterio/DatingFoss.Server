using System.Security.Cryptography;

namespace DatingFoss.Application.Authorization.Abstractions;
public interface IAuthorizationService
{
    Token GetChallenge(string username);
    void AssertIsValidChallenge(Token challenge, string dataSignedFromClient, RSAParameters clientPublicKey);
}
