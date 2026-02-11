using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Collections.Generic;
using Lex_Core.Models;

/// <summary>
/// The primary database context for the Lex application, managing the lifecycle of entity models.
/// </summary>
public class DataContext : DbContext
{
    /// <summary>
    /// Gets or sets the collection of diary entries in the database.
    /// </summary>
    public DbSet<DiaryEntry> DiaryEntries { get; set; }
    
    /// <summary>
    /// The absolute path to the SQLite database file.
    /// </summary>
    public string DbPath;

    /// <summary>
    /// Initializes a new instance of the <see cref="DataContext"/> class, setting the database path to the local application data folder.
    /// </summary>
    public DataContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "lex.db");
    }
    
    /// <summary>
    /// Configures the database to use SQLite at the specified <see cref="DbPath"/>.
    /// </summary>
    /// <param name="options">The options builder used to configure the context.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");

    /// <summary>
    /// Configures the model mapping using configurations found in the current assembly.
    /// </summary>
    /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Automatically finds every class that implements IEntityTypeConfiguration
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }
}