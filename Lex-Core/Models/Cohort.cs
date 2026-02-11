using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lex_Core.Models;

/// <summary>
/// Represents a group of students (a class or cohort) in a specific academic year.
/// </summary>
public class Cohort
{
    /// <summary>
    /// Gets or sets the unique identifier for the cohort.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the academic year of the cohort.
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Gets or sets the index or section identifier for the cohort (e.g., 1 for "Class A").
    /// </summary>
    public int Index { get; set; }

    /// <summary>
    /// Gets or sets the collection of diary entries for which this cohort is the principal (first) class.
    /// </summary>
    public ICollection<DiaryEntry> PrincipalCohortDiaryEntries { get; set; } = new List<DiaryEntry>();

    /// <summary>
    /// Gets or sets the collection of subjects taught to this cohort.
    /// </summary>
    public ICollection<Subject> Subjects { get; set; } = new List<Subject>();

    /// <summary>
    /// Gets or sets the collection of diary entries that this cohort utilizes as they advance.
    /// </summary>
    public ICollection<DiaryEntry> OtherDiaryEntries { get; set; } = new List<DiaryEntry>();
}

/// <summary>
/// Configures the entity framework mapping for the <see cref="Cohort"/> model.
/// </summary>
public class CohortConfiguration : IEntityTypeConfiguration<Cohort>
{
    /// <summary>
    /// Configures the properties and relationships for the <see cref="Cohort"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity.</param>
    public void Configure(EntityTypeBuilder<Cohort> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Index).IsRequired();
        builder.Property(x => x.Year).IsRequired();
    }
}