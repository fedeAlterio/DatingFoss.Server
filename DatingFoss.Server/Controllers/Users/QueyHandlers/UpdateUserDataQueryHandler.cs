using AutoMapper;
using DatingFoss.Application.Users.Requests;
using DatingFoss.Domain;
using DatingFoss.Server.Controllers.Users.Queries;
using DatingFoss.Server.Controllers.Users.Responses;
using DatingFoss.Server.Controllers.QueryHandlers;
using MediatR;

namespace DatingFoss.Server.Controllers.Users.QueyHandlers;

public class UpdateUserDataQueryHandler : IRequestHandler<UpdateUserDataQuery, UpdateUserDataResponseDTO>
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public UpdateUserDataQueryHandler(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<UpdateUserDataResponseDTO> Handle(UpdateUserDataQuery query, CancellationToken cancellationToken)
    {
        var request = CreateRequest(query, query.UpdateUserData!);
        var response = await _mediator.Send(request, cancellationToken);
        var responseDTO = _mapper.Map<UpdateUserDataResponseDTO>(response);
        return responseDTO;
    }

    private UpdateUserDataRequest CreateRequest(UpdateUserDataQuery query, DTOs.UpdateUserDataDTO userData)
    {
        var user = CreateUser(query, userData!);
        var request = new UpdateUserDataRequest { User = user };
        return request;
    }

    private User CreateUser(UpdateUserDataQuery query, DTOs.UpdateUserDataDTO userData)
    {
        return new User
        {
            PrivateInfo = _mapper.Map<UserPrivateInfo>(userData!.PrivateInfo),
            PublicInfo = _mapper.Map<UserPublicInfo>(userData!.PublicInfo),
            Username = query.UserIdentity!.Username,
        };
    }    
}
