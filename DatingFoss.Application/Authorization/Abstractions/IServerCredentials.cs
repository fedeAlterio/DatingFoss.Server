using System.Security.Cryptography;

namespace DatingFoss.Application.Authorization.Abstractions;
public interface IServerCredentials
{
    RSAParameters PrivateKey { get; }
    RSAParameters PublicKey { get; }
}
