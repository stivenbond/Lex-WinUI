using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Collections.Generic;
using Lex_Core.Models;

public class DataContext : DbContext
{
    public DbSet<DiaryEntry> DiaryEntries { get; set; }
    
    
    public string DbPath;
    public DataContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "lex.db");
    }
    
    //TODO Find source of DBContextOptionsBuilder
    protected override void OnConfiguring(DBContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Automatically finds every class that implements IEntityTypeConfiguration
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);
    }
}