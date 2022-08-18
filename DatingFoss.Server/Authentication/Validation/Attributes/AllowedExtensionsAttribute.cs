using DatingFoss.Server.Authentication.Validation.Exception;
using Microsoft.AspNetCore.StaticFiles;
using System.ComponentModel.DataAnnotations;

namespace DatingFoss.Server.Authentication.Validation.Attributes;

public class AllowedExtensionsAttribute : ValidationAttribute
{
    private readonly List<string> _allowedContentTypes;

    public AllowedExtensionsAttribute(params string[] extensions)
    {
        _allowedContentTypes = extensions.Select(GetContentType).ToList();
    }


    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not IFormFile formFile)
            return new InvalidTypeValidationResult(typeof(IFormFile), validationContext.MemberName);

        if (!_allowedContentTypes.Contains(formFile.ContentType))
            return new($"Invalid Content type for member {validationContext.MemberName}");

        if (formFile.ContentType != GetContentType(formFile.FileName))
            return new ($"Content type does not match with file name");

        return ValidationResult.Success;
    }

    private string GetContentType(string fileName)
    {
        var provider = new FileExtensionContentTypeProvider();
        if (!provider.TryGetContentType(fileName, out var contentType))
            contentType = "application/octet-stream";
        return contentType;
    }
}
