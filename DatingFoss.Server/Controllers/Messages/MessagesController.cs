using AutoMapper;
using DatingFoss.Server.Authentication.Extensions;
using DatingFoss.Server.Controllers.Messages.ActionBodies;
using DatingFoss.Server.Controllers.Messages.ActionsResponses;
using DatingFoss.Server.Controllers.Messages.Queries;
using DatingFoss.Server.Controllers.Messages.Responses;
using DatingFoss.Server.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DatingFoss.Server.Controllers.Messages;

[ApiController]
[Route("[Controller]")]
public class MessageController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public MessageController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }


    [Authorize]
    [HttpPost]
    [Route("[Action]")]
    public async Task<SendMessageResponseDTO> Send(SendMessageQueryBody body, CancellationToken cancellationToken)
    {
        var userIdentity = this.GetUserIdentity();
        var messageDto = new MessageDTO
        {
            FromUsername = userIdentity.Username,
            Content = body.Content,
            ToUsername = body.ToUsername
        };
        var query = new SendMessageQuery { Message = messageDto };
        var response = await _mediator.Send(query, cancellationToken);
        return response;
    }


    [Authorize]
    [HttpPost]
    [Route("[Action]")]
    public async Task<List<MessagesResponse>> Fetch(GetMessagesQuery getMessagesQuery, CancellationToken cancellationToken)
    {
        var userIdentity = this.GetUserIdentity();
        getMessagesQuery = getMessagesQuery with { ToUsername = userIdentity.Username };
        var response = await _mediator.Send(getMessagesQuery, cancellationToken);
        return _mapper.Map<List<MessagesResponse>>(response.Messages);
    }
}
