using DatingFoss.Application.Users.Responses;
using MediatR;

namespace DatingFoss.Application.Users.Requests;
public class UploadPrivatePictureRequest : IRequest<UploadPrivatePictureResponse>
{
    public string? Username { get; init; }
    public string? Picture { get; init; }
    public int KeyIndex { get; init; }
}
