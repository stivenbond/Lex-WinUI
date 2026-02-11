using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lex_Core.Models;

public class Subject
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int LevelAsYear { get; set; }

    public ICollection<Lesson> Lessons { get; set; }
    public ICollection<Cohort> Cohorts { get; set; }
}

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.LevelAsYear).IsRequired();
    }
}