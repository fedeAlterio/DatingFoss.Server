namespace DatingFoss.Application.Authorization;
public record Token(Challenge Challenge, string ServerSignedToken);
public record Challenge(string DataToSign, string Username, DateTime ExpirationDate);
