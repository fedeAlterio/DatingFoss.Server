using DatingFoss.Application.Encryption.Abstractions;
using System.Security.Cryptography;
using System.Text;

namespace DatingFoss.Infrastructure.Encryption;

public class EncryptionService : IEncryptionService
{
    public RSAParameters RSAParametersFromExponentAndModulus(string exponentBase64, string modulusBase64)
    {
        using var cryptoService = new RSACryptoServiceProvider();
        var rsaParameters = new RSAParameters()
        {
            Modulus = Convert.FromBase64String(modulusBase64),
            Exponent = Convert.FromBase64String(exponentBase64)
        };

        cryptoService.ImportParameters(rsaParameters);

        return rsaParameters;
    }


    /// <summary>
    /// Converts a plain text to an encrypted Base64 string
    /// </summary>
    public string Encrypt(string plainText, RSAParameters key)
    {
        var plainTextBytes = Encoding.Unicode.GetBytes(plainText);
        var encryptedBytes = Encrypt(plainTextBytes, key);
        var encryptedString = Convert.ToBase64String(encryptedBytes);
        return encryptedString;
    }

    public byte[] Encrypt(byte[] plainBytes, RSAParameters key)
    {
        using var rsaService = new RSACryptoServiceProvider();
        rsaService.ImportParameters(key);
        var encryptedBytes = rsaService.Encrypt(plainBytes, false);
        return encryptedBytes;
    }


    /// <summary>
    /// Decrypts an encrypted Base64 string with a given key
    /// </summary>
    public string Decrpyt(string encryptedText, RSAParameters key)
    {
        using var rsaService = new RSACryptoServiceProvider();
        rsaService.ImportParameters(key);
        var encryptedBytes = Convert.FromBase64String(encryptedText);
        var plainTextBytes = Decrpyt(encryptedBytes, key);
        var plainTextString = Encoding.Unicode.GetString(plainTextBytes);
        return plainTextString;
    }

    public byte[] Decrpyt(byte[] encryptedBytes, RSAParameters key)
    {
        using var rsaService = new RSACryptoServiceProvider();
        rsaService.ImportParameters(key);
        var plainTextBytes = rsaService.Decrypt(encryptedBytes, false);
        return plainTextBytes;
    }



    /// <summary>
    /// Hashes and signs a string with a given key
    /// </summary>
    public string HashAndSign(string dataToSign, RSAParameters key)
    {
        var toSignBytes = Encoding.Unicode.GetBytes(dataToSign);
        var signedBytes = HashAndSign(toSignBytes, key);
        var signedTextString = Convert.ToBase64String(signedBytes);
        return signedTextString;
    }
    public byte[] HashAndSign(byte[] dataToSign, RSAParameters key)
    {
        using var cryptoService = new RSACryptoServiceProvider();
        cryptoService.ImportParameters(key);
        return cryptoService.SignData(dataToSign, SHA256.Create());
    }



    /// <summary>
    /// Returns true iff <paramref name="signedData"/> Base64 is not obtained signing <paramref name="dataToVerify"/> with private key 
    /// associated with <paramref name="publicKey"/>
    /// </summary>
    public bool VerifyIsSigned(string dataToVerify, string signedData, RSAParameters publicKey)
    {
        var bytesToVerify = Encoding.Unicode.GetBytes(dataToVerify);
        var signedBytes = Convert.FromBase64String(signedData);
        return VerifyIsSigned(bytesToVerify, signedBytes, publicKey);
    }
    public bool VerifyIsSigned(byte[] dataToVerify, byte[] signedData, RSAParameters key)
    {
        using var cryptoService = new RSACryptoServiceProvider();
        cryptoService.ImportParameters(key);
        return cryptoService.VerifyData(dataToVerify, SHA256.Create(), signedData);
    }
}
