namespace Lex_Core;

/// <summary>
/// A marker class used to identify the Lex-Core assembly for reflection and assembly scanning purposes.
/// This class is sealed and cannot be instantiated.
/// </summary>
public sealed class CoreMarker
{
    /// <summary>
    /// Prevents a default instance of the <see cref="CoreMarker"/> class from being created.
    /// </summary>
    private CoreMarker() { }

    /// <summary>
    /// Gets the assembly containing the Lex-Core services.
    /// </summary>
    public static System.Reflection.Assembly Assembly => typeof(CoreMarker).Assembly;
}