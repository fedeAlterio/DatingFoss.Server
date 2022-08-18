using DatingFoss.Application.Authorization.Requests;
using DatingFoss.Application.Authorization.Responses;
using DatingFoss.Application.Repositories.Abstractions;
using MediatR;

namespace DatingFoss.Application.Authorization.RequestHandlers;
public class DoesUserExistHandler : IRequestHandler<DoesUserExistReqest, DoesUserExistResponse>
{
    private readonly IUsersService _userRepository;

    public DoesUserExistHandler(IUsersService userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<DoesUserExistResponse> Handle(DoesUserExistReqest request, CancellationToken cancellationToken)
    {
        var doesUserExist = await _userRepository.Exists(request.Username, cancellationToken);
        return new() { DoesUserExist = doesUserExist };
    }
}
