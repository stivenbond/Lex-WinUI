using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lex_Core.Models;

/// <summary>
/// Specifies the days of the week for scheduling.
/// </summary>
public enum DayOfWeek
{
    /// <summary> Monday </summary>
    Monday = 1,
    /// <summary> Tuesday </summary>
    Tuesday = 2,
    /// <summary> Wednesday </summary>
    Wednesday = 3,
    /// <summary> Thursday </summary>
    Thursday = 4,
    /// <summary> Friday </summary>
    Friday = 5,
    /// <summary> Saturday </summary>
    Saturday = 6,
    /// <summary> Sunday </summary>
    Sunday = 7
}  

/// <summary>
/// Represents an entry in a weekly schedule, linking a subject to a cohort at a specific time.
/// </summary>
public class ScheduleEntry
{
    /// <summary>
    /// Gets or sets the unique identifier for the schedule entry.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the period number during the day (e.g., 1 for the first lesson).
    /// </summary>
    public int PeriodNumber { get; set; }

    /// <summary>
    /// Gets or sets the day of the week for this entry.
    /// </summary>
    public DayOfWeek Day { get; set; }

    /// <summary>
    /// Gets or sets the foreign key for the subject being taught.
    /// </summary>
    public int SubjectId { get; set; }

    /// <summary>
    /// Gets or sets the subject being taught in this period.
    /// </summary>
    public Subject Subject { get; set; }

    /// <summary>
    /// Gets or sets the foreign key for the cohort taking the lesson.
    /// </summary>
    public int CohortId { get; set; }

    /// <summary>
    /// Gets or sets the cohort taking the lesson in this period.
    /// </summary>
    public Cohort Cohort { get; set; }
}

/// <summary>
/// Configures the entity framework mapping for the <see cref="ScheduleEntry"/> model.
/// </summary>
public class ScheduleEntryConfiguration : IEntityTypeConfiguration<ScheduleEntry>
{
    /// <summary>
    /// Configures the properties and relationships for the <see cref="ScheduleEntry"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity.</param>
    public void Configure(EntityTypeBuilder<ScheduleEntry> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.PeriodNumber)
            .IsRequired();

        builder.Property(x => x.Day)
            .IsRequired();

        builder.HasOne(x => x.Subject)
            .WithMany()
            .HasForeignKey(x => x.SubjectId);

        builder.HasOne(x => x.Cohort)
            .WithMany()
            .HasForeignKey(x => x.CohortId);
    }
}

