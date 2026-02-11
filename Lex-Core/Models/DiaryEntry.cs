using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lex_Core.Models;

/// <summary>
/// Represents a diary entry that provides additional context and metadata for a lesson.
/// </summary>
public class DiaryEntry
{
    /// <summary>
    /// Gets or sets the unique identifier for the diary entry.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the foreign key for the associated lesson.
    /// </summary>
    public int LessonId { get; set; }

    /// <summary>
    /// Gets or sets the foreign key for the subject this diary entry relates to.
    /// </summary>
    public int SubjectId { get; set; }

    /// <summary>
    /// Gets or sets the foreign key for the principal (first) cohort taught.
    /// </summary>
    public int PrincipalCohortId { get; set; }

    /// <summary>
    /// Gets or sets the lesson associated with this diary entry.
    /// </summary>
    public Lesson Lesson { get; set; }

    /// <summary>
    /// Gets or sets the subject related to this entry.
    /// </summary>
    public Subject Subject { get; set; }

    /// <summary>
    /// Gets or sets the first cohort that was taught the associated lesson.
    /// </summary>
    public Cohort PrincipalCohort { get; set; }

    /// <summary>
    /// Gets or sets the collection of other cohorts that utilize this diary entry.
    /// </summary>
    public ICollection<Cohort> OtherCohorts { get; set; } = new List<Cohort>();

    /// <summary>
    /// Gets or sets the JSON-serializable content of the diary entry.
    /// </summary>
    public DiaryEntryContent? Content { get; set; }
}

/// <summary>
/// Holds the detailed content of a diary entry, typically stored as JSON.
/// </summary>
public class DiaryEntryContent
{
    /// <summary>
    /// Gets or sets the primary text content of the entry.
    /// </summary>
    public string? EntryContent { get; set; }

    /// <summary>
    /// Gets or sets a list of key-value pairs representing custom fields in the entry.
    /// </summary>
    public List<EntryField>? Fields { get; set; } = new();
}

/// <summary>
/// Represents a single custom field within a diary entry.
/// </summary>
public class EntryField
{
    /// <summary>
    /// Gets or sets the name/label of the field.
    /// </summary>
    public string? FieldName { get; set; }

    /// <summary>
    /// Gets or sets the value of the field.
    /// </summary>
    public string? FieldValue { get; set; }
}

/// <summary>
/// Configures the entity framework mapping for the <see cref="DiaryEntry"/> model.
/// </summary>
public class DiaryEntryConfiguration : IEntityTypeConfiguration<DiaryEntry> 
{
    /// <summary>
    /// Configures the properties and relationships for the <see cref="DiaryEntry"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity.</param>
    public void Configure(EntityTypeBuilder<DiaryEntry> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();


        //Lesson Relationship (1-to-1)
        builder.HasOne(x => x.Lesson)
            .WithOne(l => l.DiaryEntry)
            .HasPrincipalKey<DiaryEntry>(x => x.Id);

        //Subject Relationship
        builder.HasOne(x => x.Subject)
            .WithMany()
            .HasForeignKey(x => x.SubjectId);

        //Principal Cohort Relationship
        builder.HasOne(x => x.PrincipalCohort)
            .WithMany(c => c.PrincipalCohortDiaryEntries)
            .HasForeignKey(x => x.PrincipalCohortId);

        //Other Cohorts Relationship (Many-to-Many)
        builder.HasMany(x => x.OtherCohorts)
            .WithMany(c => c.OtherDiaryEntries); 

        builder.Property(x => x.Content).IsRequired();
        builder.OwnsOne(x => x.Content, configBuilder =>
        {
            configBuilder.ToJson();
        });
    }
}