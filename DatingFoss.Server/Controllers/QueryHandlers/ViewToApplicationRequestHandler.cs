using AutoMapper;
using MediatR;

namespace DatingFoss.Server.Controllers.QueryHandlers;

public class ViewToApplicationRequestHandler<TRequestView, TRequestDomain, TResponseView>
    : IRequestHandler<TRequestView, TResponseView>
    where TRequestView : IRequest<TResponseView> where TRequestDomain : IBaseRequest
{
    // Private fields
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;



    // Initialization
    public ViewToApplicationRequestHandler(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }



    // Core
    public async Task<TResponseView> Handle(TRequestView requestView, CancellationToken cancellationToken)
    {
        var requestDomain = _mapper.Map<TRequestDomain>(requestView);
        var responseDomain = await _mediator.Send(requestDomain!, cancellationToken);
        var responseView = _mapper.Map<TResponseView>(responseDomain);
        return responseView;
    }
}
