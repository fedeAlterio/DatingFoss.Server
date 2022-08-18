using DatingFoss.Server.Controllers.Messages.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DatingFoss.Server.Controllers.Messages.Queries;

public record GetMessagesQuery : IRequest<GetMessagesResponseDTO>
{
    public string? FromUsername { get; init; }
    public string? ToUsername { get; init; }

    [Range(1, 100)]
    public int MaximumResultsCount { get; init; }
}
