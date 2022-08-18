using System.Security.Cryptography;

namespace DatingFoss.Domain;
public class RSAPublicKey
{
    public RSAPublicKey() { }
    public RSAPublicKey(RSAParameters rsaParameters)
    {
        Modulus = Convert.ToBase64String(rsaParameters.Modulus ?? Array.Empty<byte>());
        Exponent = Convert.ToBase64String(rsaParameters.Exponent ?? Array.Empty<byte>());
    }

    public string? Modulus { get; init; }
    public string? Exponent { get; init; }
}
