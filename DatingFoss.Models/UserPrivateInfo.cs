namespace DatingFoss.Domain;
public record UserPrivateInfo
{
    public EncryptedData? Sex { get; init; }
    public EncryptedData? Position { get; init; }
    public EncryptedData? Bio { get; init; }
    public EncryptedData? TextualInfo { get; init; }
    public EncryptedData? BooleanInfo { get; init; }
    public EncryptedData? TemporalInfo { get; init; }
    public EncryptedData? Interests { get; init; }
    public List<PrivatePicture> Pictures { get; init; } = new();
    public EncryptedData? Searching { get; init; }
}
