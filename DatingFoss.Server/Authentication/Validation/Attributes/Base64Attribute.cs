using DatingFoss.Server.Authentication.Validation.Exception;
using System.ComponentModel.DataAnnotations;

namespace DatingFoss.Server.Authentication.Validation.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class Base64Attribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not string str)
            return new InvalidTypeValidationResult(typeof(string), validationContext.MemberName);

        var buffer = new Span<byte>(new byte[str.Length]);
        var isBase64 = Convert.TryFromBase64String(str, buffer, out int _);

        if (!isBase64)
            return new($"{validationContext.MemberName} is not a valid Base64 string");

        return ValidationResult.Success;
    }
}
