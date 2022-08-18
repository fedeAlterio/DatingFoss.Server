using DatingFoss.Infrastructure.Encryption;
using DatingFoss.Tests.TestUtils;
using FluentAssertions;
using System;
using System.Security.Cryptography;

namespace DatingFoss.Tests.Infrastructure.Encryption;
public class EncryptionServiceTests
{
    [FactFor(nameof(EncryptionService.RSAParametersFromExponentAndModulus))]
    public void Should_ProvideRSAParametersFromModulusAndExponent()
    {
        var encryptionService = new EncryptionService();

        var (_, publicKey) = GetKeys();
        var exponent = Convert.ToBase64String(publicKey.Exponent!);
        var modulus = Convert.ToBase64String(publicKey.Modulus!);

        var newRsaParameters = encryptionService.RSAParametersFromExponentAndModulus(exponent, modulus);
        newRsaParameters.Modulus.Should().BeEquivalentTo(publicKey.Modulus);
        newRsaParameters.Exponent.Should().BeEquivalentTo(publicKey.Exponent);
    }

    [FactFor(nameof(EncryptionService.RSAParametersFromExponentAndModulus))]
    public void Should_ThrowIfTryingToGenerateRSAParametersFromIncorrectModulusOrExponent()
    {
        var encryptionService = new EncryptionService();

        var (privateKey, _) = GetKeys();
        var exponent = Convert.ToBase64String(privateKey.Exponent!);

        // Too few bytes
        byte[] incorrectModulusBytes =
        {
            214,46,220
        };

        var modulus = Convert.ToBase64String(incorrectModulusBytes);

        Action createKey = () => encryptionService.RSAParametersFromExponentAndModulus(exponent, modulus);
        createKey.Should().Throw<CryptographicException>();
    }


    [FactFor(nameof(EncryptionService.Encrypt))]
    public void Should_CorrectlyEncryptAString()
    {
        var encryptionService = new EncryptionService();

        var (privateKey, publicKey) = GetKeys();

        var plainText = "Hello";
        var encryptedText = encryptionService.Encrypt(plainText, publicKey);
        var decryptedText = encryptionService.Decrpyt(encryptedText, privateKey);

        decryptedText.Should().Be(plainText);
    }


    [FactFor(nameof(EncryptionService.Encrypt))]
    public void Should_NotDecryptIfSameKeyUsedForEncryptAndDecrypt()
    {
        var encryptionService = new EncryptionService();

        var (_, publicKey) = GetKeys();
        var plainText = "Hello";
        var encryptedText = encryptionService.Encrypt(plainText, publicKey);

        Action decryptionWithSameKey = () => encryptionService.Decrpyt(encryptedText, publicKey);
        decryptionWithSameKey.Should().Throw<CryptographicException>();
    }


    [FactFor(nameof(EncryptionService.HashAndSign))]
    public void Should_CorrectlySignAString()
    {
        var encryptionService = new EncryptionService();
        var (privateKey, publicKey) = GetKeys();
        var toSignData = "Hello";
        var signedData = encryptionService.HashAndSign(toSignData, privateKey);

        var isSigned = encryptionService.VerifyIsSigned(dataToVerify: toSignData, signedData: signedData, publicKey: publicKey);
        isSigned.Should().BeTrue();

        isSigned = encryptionService.VerifyIsSigned(dataToVerify: "shadhak", signedData: signedData, publicKey: publicKey);
        isSigned.Should().BeFalse();
    }



    // Utils
    private (RSAParameters privateKey, RSAParameters publicKey) GetKeys()
    {
        using var cryptoServiceProvider = new RSACryptoServiceProvider();
        var privateKey = cryptoServiceProvider.ExportParameters(true);
        var publicKey = cryptoServiceProvider.ExportParameters(false);
        return (privateKey, publicKey);
    }
}
