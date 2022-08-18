namespace DatingFoss.Server.Authentication.Validation.Attributes;

public class PictureAttribute : AllowedExtensionsAttribute
{
    public PictureAttribute() : base(".png", ".jpg")
    {

    }
}
