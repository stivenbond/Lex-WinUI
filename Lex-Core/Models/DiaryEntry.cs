using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lex_Core.Models;

public class DiaryEntry
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    
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
        builder.Property(x => x.LessonId).IsRequired(); //TODO Add it as a foreign key
        builder.Property(x => x.Content).IsRequired();
        builder.OwnsOne(x => x.Content, configBuilder =>
        {
            configBuilder.ToJson();
        });
    }
}