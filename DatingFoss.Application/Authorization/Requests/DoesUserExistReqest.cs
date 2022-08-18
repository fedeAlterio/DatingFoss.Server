using DatingFoss.Application.Authorization.Responses;
using MediatR;

namespace DatingFoss.Application.Authorization.Requests;
public class DoesUserExistReqest : IRequest<DoesUserExistResponse>
{
    public string? Username { get; init; }
}
