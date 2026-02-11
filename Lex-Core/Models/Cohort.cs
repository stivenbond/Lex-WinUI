using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lex_Core.Models;

public class Cohort
{
    public int Id { get; set; }
    public int Year { get; set; }
    public int Index { get; set; }

    public ICollection<DiaryEntry> PrincipalCohortDiaryEntries { get; set; } = new List<DiaryEntry>();
    public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    public ICollection<DiaryEntry> OtherDiaryEntries { get; set; } = new List<DiaryEntry>();
}

public class CohortConfiguration : IEntityTypeConfiguration<Cohort>
{
    public void Configure(EntityTypeBuilder<Cohort> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Index).IsRequired();
        builder.Property(x => x.Year).IsRequired();
    }
}