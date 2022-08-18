using DatingFoss.Application.Authorization.Abstractions;
using System.Security.Cryptography;

namespace DatingFoss.Infrastructure.Authorization;
public class MockServerCredentials : IServerCredentials
{
    public MockServerCredentials()
    {
        using var cryptoServiceProvider = new RSACryptoServiceProvider();
        PrivateKey = cryptoServiceProvider.ExportParameters(true);
        PublicKey = cryptoServiceProvider.ExportParameters(false);
    }

    public RSAParameters PrivateKey { get; }
    public RSAParameters PublicKey { get; }
}
