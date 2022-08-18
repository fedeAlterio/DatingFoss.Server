using DatingFoss.Application.Users.Responses;
using MediatR;

namespace DatingFoss.Application.Users.Requests;
public class UploadPublicPictureRequest : IRequest<UploadPubilcPictureResponse>
{
    public string? Username { get; init; }
    public string? Picture { get; init; }
}
