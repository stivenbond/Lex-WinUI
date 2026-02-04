using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lex_Core.Models;

public class Cohort
{
    public int Id { get; set; }
    public int Year { get; set; }
    public int Index { get; set; }

    public ICollection<DiaryEntry> PrincipalCohortDiaryEntries { get; set; }
    
}

public class DiaryEntryConfiguration : IEntityTypeConfiguration<DiaryEntry>
{
    public void Configure(EntityTypeBuilder<DiaryEntry> builder)
    {/* FOR REFERENCE   
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.LessonId).IsRequired(); //TODO Add it as a foreign key
        builder.Property(x => x.Content).IsRequired();
        builder.OwnsOne(x => x.Content, configBuilder =>
        {
            configBuilder.ToJson();
        });*/
    }
}