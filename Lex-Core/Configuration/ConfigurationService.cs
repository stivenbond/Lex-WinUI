using System.Text.Json;
using System.IO;

namespace Lex_Core.Configuration;

/// <summary>
/// Interface for managing application configuration.
/// </summary>
public interface IConfigurationService
{
    /// <summary>
    /// Loads the configuration from the persistent store or defaults.
    /// </summary>
    AppConfig Load();

    /// <summary>
    /// Saves the provided configuration to the persistent store.
    /// </summary>
    void Save(AppConfig config);
}

/// <summary>
/// Service implementation for managing application configuration stored as JSON.
/// </summary>
/// <remarks>
/// This service handles the loading and saving of <see cref="AppConfig"/>. 
/// It implements a fallback mechanism to support MSIX-style read-only defaults in the installation directory 
/// and writable user-specific settings in the local application data folder.
/// </remarks>
public class ConfigurationService : IConfigurationService
{
    /// <summary>
    /// The absolute path to the writeable user-specific configuration file.
    /// </summary>
    private readonly string _configPath;

    /// <summary>
    /// The absolute path to the read-only default configuration file provided at installation.
    /// </summary>
    private readonly string _defaultConfigPath;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigurationService"/> class.
    /// Sets up the paths for the user-specific and default configuration files and ensures the user-specific directory exists.
    /// </summary>
    public ConfigurationService()
    {
        // Path in LocalAppData for writable settings
        var localFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var appFolder = Path.Combine(localFolder, "Lex");
        Directory.CreateDirectory(appFolder);
        _configPath = Path.Combine(appFolder, "appconfig.json");

        // Path in installation directory for read-only defaults (MSIX)
        _defaultConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
    }

    /// <inheritdoc />
    public AppConfig Load()
    {
        // 1. Try to load user-specific config
        if (File.Exists(_configPath))
        {
            try
            {
                var json = File.ReadAllText(_configPath);
                return JsonSerializer.Deserialize<AppConfig>(json) ?? CreateDefaultConfig();
            }
            catch
            {
                return CreateDefaultConfig();
            }
        }

        // 2. Fallback to MSIX install-time defaults
        if (File.Exists(_defaultConfigPath))
        {
            try
            {
                var json = File.ReadAllText(_defaultConfigPath);
                var config = JsonSerializer.Deserialize<AppConfig>(json) ?? CreateDefaultConfig();
                
                // Save a local copy for future changes
                Save(config);
                return config;
            }
            catch
            {
                // Fallback to hardcoded defaults
            }
        }

        // 3. Hardcoded defaults
        var defaults = CreateDefaultConfig();
        Save(defaults);
        return defaults;
    }

    /// <inheritdoc />
    public void Save(AppConfig config)
    {
        var json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_configPath, json);
    }

    /// <summary>
    /// Creates a new <see cref="AppConfig"/> instance with hardcoded default values.
    /// </summary>
    /// <returns>A new <see cref="AppConfig"/> instance containing the application defaults.</returns>
    private AppConfig CreateDefaultConfig()
    {
        var localFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var appFolder = Path.Combine(localFolder, "Lex");
        
        return new AppConfig
        {
            DatabasePath = Path.Combine(appFolder, "lex.db"),
            DefaultLanguage = "en-US",
            PreferredTheme = "System",
            EnableAutoSync = false
        };
    }
}
