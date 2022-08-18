namespace DatingFoss.Server.Configuration.Abstractions;

public interface IDirectoriesInfo
{
    string? PublicPicturesFolderName { get; }
    string? PrivatePicturesFolderName { get; }
    string? ApplicationRootPath { get; }
    string? UsersFolderName { get; }
    string GetPublicPicturesPath(string username);
    string GetPrivatePicturesPath(string username);
}
