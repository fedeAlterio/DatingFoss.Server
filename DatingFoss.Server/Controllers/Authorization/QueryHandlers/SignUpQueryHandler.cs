using AutoMapper;
using DatingFoss.Application.Authorization.Requests;
using DatingFoss.Server.Controllers.Authorization.Abstractions;
using DatingFoss.Server.Controllers.Authorization.Queries;
using DatingFoss.Server.Controllers.Authorization.Responses;
using MediatR;

namespace DatingFoss.Server.Controllers.Authorization.QueryHandlers;

public class SignUpQueryHandler : IRequestHandler<SignUpQuery, SignUpResponseDTO>
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IJWTService _jwtService;

    public SignUpQueryHandler(IMediator mediator, IMapper mapper, IJWTService jwtService)
    {
        _mediator = mediator;
        _mapper = mapper;
        _jwtService = jwtService;
    }

    public async Task<SignUpResponseDTO> Handle(SignUpQuery query, CancellationToken cancellationToken)
    {
        var signupRequest = _mapper.Map<SignUpRequest>(query);
        var signupResponse = await _mediator.Send(signupRequest, cancellationToken);
        var token = _jwtService.BuildToken(signupResponse.User!);
        return new() { Jwt = token };
    }
}
