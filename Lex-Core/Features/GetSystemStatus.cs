using MediatR;

namespace Lex_Core.Features;

/// <summary>
/// A simple query to check the system status and verify MediatR integration.
/// </summary>
public record GetSystemStatusQuery : IRequest<string>;

/// <summary>
/// Handler for the <see cref="GetSystemStatusQuery"/>.
/// </summary>
public class GetSystemStatusHandler : IRequestHandler<GetSystemStatusQuery, string>
{
    /// <inheritdoc />
    public Task<string> Handle(GetSystemStatusQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult("Lex-Core is operational and MediatR is properly configured.");
    }
}
