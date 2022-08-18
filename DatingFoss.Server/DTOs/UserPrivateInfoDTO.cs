using DatingFoss.Server.Mapping;
using System.Text.Json.Serialization;

namespace DatingFoss.Server.DTOs;

public class UserPrivateInfoDTO
{
    public EncryptedDataDTO? Sex { get; init; }


    [JsonPropertyName("location")]
    public EncryptedDataDTO? Position { get; init; }

    public EncryptedDataDTO? Bio { get; init; }


    [JsonPropertyName("textInfo")]
    public EncryptedDataDTO? TextualInfo { get; init; }


    [JsonPropertyName("boolInfo")]
    public EncryptedDataDTO? BooleanInfo { get; init; }


    [JsonPropertyName("dateInfo")]
    public EncryptedDataDTO? TemporalInfo { get; init; }

    public EncryptedDataDTO? Interests { get; init; }
    public List<PrivatePictureDTO>? Pictures { get; init; }
    public EncryptedDataDTO? Searching { get; init; }
}
