using System.Security.Cryptography;

namespace DatingFoss.Application.Encryption.Abstractions;
public interface IEncryptionService
{
    RSAParameters RSAParametersFromExponentAndModulus(string exponent, string modulus);
    string Encrypt(string plainText, RSAParameters key);
    byte[] Encrypt(byte[] plainBytes, RSAParameters key);
    string Decrpyt(string encryptedText, RSAParameters key);
    byte[] Decrpyt(byte[] encryptedBytes, RSAParameters key);
    string HashAndSign(string dataToSign, RSAParameters key);
    byte[] HashAndSign(byte[] dataToSign, RSAParameters key);
    bool VerifyIsSigned(string dataToVerify, string signedData, RSAParameters publicKey);
    bool VerifyIsSigned(byte[] dataToVerify, byte[] signedData, RSAParameters key);
}
