using AutoMapper;
using DatingFoss.Domain;
using DatingFoss.Server.DTOs;

namespace DatingFoss.Server.Mapping;

public class EncryptedDataMap : Profile
{
    public EncryptedDataMap()
    {
        CreateMap<EncryptedData, EncryptedDataDTO>();
        CreateMap<EncryptedDataDTO, EncryptedData>();
    }
}
