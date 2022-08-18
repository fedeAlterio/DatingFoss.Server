using AutoMapper;
using DatingFoss.Application.Authorization.Requests;
using DatingFoss.Server.Controllers.Authorization.Abstractions;
using DatingFoss.Server.Controllers.Authorization.Queries;
using DatingFoss.Server.Controllers.Authorization.Responses;
using MediatR;

namespace DatingFoss.Server.Controllers.Authorization.QueryHandlers;

public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResponseDTO>
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IJWTService _jwtService;

    public LoginQueryHandler(IMediator mediator, IMapper mapper, IJWTService jwtService)
    {
        _mediator = mediator;
        _mapper = mapper;
        _jwtService = jwtService;
    }

    public async Task<LoginResponseDTO> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var loginQuery = _mapper.Map<LoginRequest>(request);
        var loginResponse = await _mediator.Send(loginQuery, cancellationToken);
        var token = _jwtService.BuildToken(loginResponse.User!);
        return new() { Jwt = token };
    }
}
