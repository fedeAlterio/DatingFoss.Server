namespace DatingFoss.Domain.Exceptions;
public class DatingFossException : Exception
{
    public DatingFossException(string? message) : base(message)
    {
    }

    public DatingFossException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
