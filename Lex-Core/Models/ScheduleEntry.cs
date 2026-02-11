using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lex_Core.Models;

public enum DayOfWeek
{
    Monday = 1,
    Tuesday = 2,
    Wednesday = 3,
    Thursday = 4,
    Friday = 5,
    Saturday = 6,
    Sunday = 7
}

public class ScheduleEntry
{
    public int Id { get; set; }
    public int PeriodNumber { get; set; }
    public DayOfWeek Day { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
    public int CohortId { get; set; }
    public Cohort Cohort { get; set; }
}

public class ScheduleEntryConfiguration : IEntityTypeConfiguration<ScheduleEntry>
{
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

