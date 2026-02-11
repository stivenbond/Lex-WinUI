using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lex_Core.Models;

public class DiaryEntry
{
    //Metadata
    public int Id { get; set; }

    //Foreign Keys
    public int LessonId { get; set; }
    public int SubjectId { get; set; }
    public int PrincipalCohortId { get; set; }

    //Navigation Properties
    public Lesson Lesson { get; set; }
    public Subject Subject { get; set; }
    public Cohort PrincipalCohort { get; set; }

    public ICollection<Cohort> OtherCohorts { get; set; } = new List<Cohort>();

    //Content as JSON
    public DiaryEntryContent? Content { get; set; }
}

public class DiaryEntryContent
{
    public string? EntryContent { get; set; }
    public List<EntryField>? Fields { get; set; } = new();
}
public class EntryField
{
    public string? FieldName { get; set; }
    public string? FieldValue { get; set; }
}

public class DiaryEntryConfiguration : IEntityTypeConfiguration<DiaryEntry> 
{
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