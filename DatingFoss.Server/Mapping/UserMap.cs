using AutoMapper;
using DatingFoss.Domain;
using DatingFoss.Server.DTOs;

namespace DatingFoss.Server.Mapping;

public class UserMap : Profile
{
    public UserMap()
    {
        CreateMap<User, UserDTO>();
        CreateMap<UserDTO, User>();

        CreateMap<UserPublicInfo, UserPublicInfoDTO>();
        CreateMap<UserPublicInfoDTO, UserPublicInfo>();

        CreateMap<UserPrivateInfo, UserPrivateInfoDTO>();
        CreateMap<UserPrivateInfoDTO, UserPrivateInfo>();

        CreateMap<PrivatePicture, PrivatePictureDTO>();
        CreateMap<PrivatePictureDTO, PrivatePicture>();
    }
}
