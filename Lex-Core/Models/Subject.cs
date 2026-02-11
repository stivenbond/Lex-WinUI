using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lex_Core.Models;

/// <summary>
/// Represents a school subject taught in a curriculum.
/// </summary>
public class Subject
{
    /// <summary>
    /// Gets or sets the unique identifier for the subject.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the subject (e.g., "Mathematics").
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the academic level or year associated with the subject.
    /// </summary>
    public int LevelAsYear { get; set; }

    /// <summary>
    /// Gets or sets the collection of lessons associated with this subject.
    /// </summary>
    public ICollection<Lesson> Lessons { get; set; }

    /// <summary>
    /// Gets or sets the collection of cohorts that take this subject.
    /// </summary>
    public ICollection<Cohort> Cohorts { get; set; }
}

/// <summary>
/// Configures the entity framework mapping for the <see cref="Subject"/> model.
/// </summary>
public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    /// <summary>
    /// Configures the properties and relationships for the <see cref="Subject"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity.</param>
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.LevelAsYear).IsRequired();
    }
}