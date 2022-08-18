using DatingFoss.Server.Configuration.Abstractions;

namespace DatingFoss.Server.Configuration;

public class DirectoriesInfo : IDirectoriesInfo
{
    public DirectoriesInfo(IConfiguration configuration)
    {
        configuration.GetSection("DirectoriesInfo").Bind(this);
        ApplicationRootPath = configuration.GetValue<string>(WebHostDefaults.ContentRootKey);

        ApplicationDataPath ??= "";
        if (!Path.IsPathFullyQualified(ApplicationDataPath))
            ApplicationDataPath = Path.Combine(ApplicationRootPath, ApplicationDataPath);
    }


    public string? PublicPicturesFolderName { get; init; }
    public string? PrivatePicturesFolderName { get; init; }
    public string? ApplicationRootPath { get; private set; }
    public string? UsersFolderName { get; init; }
    public string? ApplicationDataPath { get; init; }
    public string? UsersDataRootPath => Path.Join(ApplicationDataPath, UsersFolderName);
    public string GetPublicPicturesPath(string username) => Path.Join(UsersDataRootPath, username, PublicPicturesFolderName);
    public string GetPrivatePicturesPath(string username) => Path.Join(UsersDataRootPath, username, PrivatePicturesFolderName);
}
