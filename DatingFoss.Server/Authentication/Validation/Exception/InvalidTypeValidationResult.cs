using System.ComponentModel.DataAnnotations;

namespace DatingFoss.Server.Authentication.Validation.Exception;

public class InvalidTypeValidationResult : ValidationResult
{
    public InvalidTypeValidationResult(Type expectedType, string? parameterName) : base($"Expected a {expectedType} for parameter {parameterName}")
    {
    }
}
