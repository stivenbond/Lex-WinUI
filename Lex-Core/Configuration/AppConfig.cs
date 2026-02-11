namespace Lex_Core.Configuration;

/// <summary>
/// Represents the persistent user configuration for the Lex application.
/// </summary>
/// <remarks>
/// This configuration is typically serialized to a JSON file in the local application data folder. 
/// It includes paths and behavioral settings that persist across application sessions.
/// </remarks>
public class AppConfig
{
    /// <summary>
    /// Gets or sets the path to the SQLite database file.
    /// </summary>
    public string DatabasePath { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the default language for the application (e.g., "en-US", "sq-AL").
    /// </summary>
    public string DefaultLanguage { get; set; } = "en-US";

    /// <summary>
    /// Gets or sets the preferred UI theme (e.g., "Light", "Dark", "System").
    /// </summary>
    public string PreferredTheme { get; set; } = "System";

    /// <summary>
    /// Gets or sets whether to use auto-sync features.
    /// </summary>
    public bool EnableAutoSync { get; set; } = false;
}
