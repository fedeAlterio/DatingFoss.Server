using DatingFoss.Server.Authentication;
using DatingFoss.Server.Controllers.Users.DTOs;
using DatingFoss.Server.Controllers.Users.Responses;
using MediatR;

namespace DatingFoss.Server.Controllers.Users.Queries;

public class UpdateUserDataQuery : IRequest<UpdateUserDataResponseDTO>
{
    public UserIdentity? UserIdentity { get; init; }
    public UpdateUserDataDTO? UpdateUserData { get; init; }
}
