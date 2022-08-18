using DatingFoss.Domain.Exceptions;

namespace DatingFoss.Server.Services.Exception;

public class InvalidFileNameExcepion : DatingFossException
{
    public InvalidFileNameExcepion(string? filename) : base($"{filename} is not a valid filename")
    {
    }
}
