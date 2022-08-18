using DatingFoss.Server.Authentication.Validation.Exception;
using System.ComponentModel.DataAnnotations;

namespace DatingFoss.Server.Authentication.Validation.Attributes;

public class FileSizeAttribute : ValidationAttribute
{
    public FileSizeAttribute(long maxSizeInBytes, long minSizeInBytes = 1)
    {
        MaxSizeInBytes = maxSizeInBytes;
        MinSizeInBytes = minSizeInBytes;
    }

    public long MaxSizeInBytes { get; }
    public long MinSizeInBytes { get; }


    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not IFormFile formFile)
            return new InvalidTypeValidationResult(typeof(IFormFile), validationContext.MemberName);

        if (formFile.Length <= MinSizeInBytes || formFile.Length >= MaxSizeInBytes)
            return new($"File length should be between {MinSizeInBytes} and {MaxSizeInBytes} bytes");

        return ValidationResult.Success;
    }
}
