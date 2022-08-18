using DatingFoss.Application.Authorization;
using DatingFoss.Application.Authorization.Abstractions;
using DatingFoss.Application.Encryption.Abstractions;
using System.Security.Cryptography;
using System.Text.Json;

namespace DatingFoss.Infrastructure.Authorization;
public class AuthorizationService : IAuthorizationService
{
    // Private fields
    private readonly static Random _random = new();
    private readonly IServerCredentials _serverCredentials;
    private readonly IEncryptionService _encryptionService;



    // Initialization
    public AuthorizationService(IServerCredentials serverCredentials, IEncryptionService encryptionService)
    {
        _serverCredentials = serverCredentials;
        _encryptionService = encryptionService;
    }



    // Public
    public Token GetChallenge(string username)
    {
        var challengeString = GenerateChallengeString(20);
        var expirationDate = DateTime.Now.AddMinutes(1);
        var token = new Challenge(challengeString, username, expirationDate);
        var tokenJson = JsonSerializer.Serialize(token);
        var signedTokenJson = _encryptionService.HashAndSign(tokenJson, _serverCredentials.PrivateKey);
        var challenge = new Token(token, signedTokenJson);
        return challenge;
    }

    public void AssertIsValidChallenge(Token token, string dataSignedFromClient, RSAParameters clientPublicKey)
    {
        var challenge = token.Challenge;
        if (challenge.ExpirationDate < DateTime.Now)
            throw new InvalidOperationException($"Token is expired in {challenge.ExpirationDate}");

        var tokenJson = JsonSerializer.Serialize(token.Challenge);
        var isSignedByServer = _encryptionService.VerifyIsSigned(tokenJson, token.ServerSignedToken, _serverCredentials.PublicKey);
        if (!isSignedByServer)
            throw new InvalidOperationException($"Data not correctly signed by server");

        var isSignedBytClient = _encryptionService.VerifyIsSigned(token.Challenge.DataToSign, dataSignedFromClient, clientPublicKey);
        // if (!isSignedBytClient)
        //     throw new InvalidOperationException($"Data not correctly signed by client");
    }



    // Utils
    private static string GenerateChallengeString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var letters = Enumerable.Repeat(chars, length).Select(s => s[_random.Next(s.Length)]);
        return new string(letters.ToArray());
    }
}
