using MediatR;

namespace Lex_Core.Features;

/// <summary>
/// A simple query to check the system status and verify MediatR integration.
/// </summary>
/// <remarks>
/// This query serves as a diagnostics tool to ensure that the mediator pipeline is correctly configured and that the core assembly is accessible.
/// </remarks>
public record GetSystemStatusQuery : IRequest<string>;

/// <summary>
/// The message handler for the <see cref="GetSystemStatusQuery"/>.
/// </summary>
/// <remarks>
/// This handler returns a standard operational message to indicate success.
/// </remarks>
public class GetSystemStatusHandler : IRequestHandler<GetSystemStatusQuery, string>
{
    /// <inheritdoc />
    public Task<string> Handle(GetSystemStatusQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult("Lex-Core is operational and MediatR is properly configured.");
    }
}
