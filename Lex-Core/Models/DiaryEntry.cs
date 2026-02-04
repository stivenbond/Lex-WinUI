using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lex_Core.Models;

public class DiaryEntry
{
    //Metadata
    public int Id { get; set; }

    //Foreign Keys
    public int LessonId {get; set;}
    public int PrincipalCohortId {get;set;}

    //TODO Navigation Properties (check virtual constraint reason)
    public Lesson Lesson { get; set; } // Lesson Foreign Key
    public Cohort? PrincipalCohort { get; set; } //Principal Cohort Foreign Key to store the first class that is taught a lesson

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


        //Lesson FK Relationship
        builder.HasOne(x => x.Lesson)
            .WithOne(l => l.DiaryEntry)
            .HasForeignKey(x => x.LessonId);

        //Principal Cohort FK Relationship
        builder.HasOne(x => x.PrincipalCohort)
            .WithMany(c => c.PrincipalCohortDiaryEntries)
            .HasForeignKey(x => x.PrincipalCohortId);
        
        builder.Property(x => x.Content).IsRequired();
        builder.OwnsOne(x => x.Content, configBuilder =>
        {
            configBuilder.ToJson();
        });
    }
}