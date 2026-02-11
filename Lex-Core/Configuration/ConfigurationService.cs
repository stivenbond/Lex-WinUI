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
/// Supports MSIX-style read-only defaults and writable user settings.
/// </summary>
public class ConfigurationService : IConfigurationService
{
    private readonly string _configPath;
    private readonly string _defaultConfigPath;

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
