using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json.Serialization;
using ABI.Microsoft.UI.Xaml.Documents;

namespace Lex_Core.Models;

public enum BlockType
{
    Text = 1,
    Attachment = 2 //TODO Make an attachments table
}

public enum TextType
{
    PlainText = 1,
    Heading = 2,
    UnorderedList = 3,
    OrderedList = 4,
}

public enum AttachmentType
{
    Image = 1,
    Video = 2
}

public class Lesson
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public List<ContentBlock>? LessonContents { get; set; }

    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
    
    public int DiaryEntryId { get; set; }
    public DiaryEntry DiaryEntry { get; set; }
}

[JsonPolymorphic(TypeDiscriminatorPropertyName =  "Type")]
[JsonDerivedType(typeof(TextBlock),typeDiscriminator: (int)BlockType.Text)]
[JsonDerivedType(typeof(AttachmentBlock),typeDiscriminator: (int)BlockType.Attachment)]
public abstract class ContentBlock
{
    public int BlockId { get; set; }
    public BlockType Type { get; set; }
}

public class TextBlock : ContentBlock
{
    public TextType Formatting { get; set; }
    public string? Content { get; set; }
}

public class AttachmentBlock : ContentBlock
{
    public AttachmentType Kind { get; set; }
    public int AttachmentId { get; set; }
}

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Title).IsRequired();

        // Subject Relationship
        builder.HasOne(x => x.Subject)
            .WithMany(s => s.Lessons)
            .HasForeignKey(x => x.SubjectId);

        // DiaryEntry Relationship (1-to-1)
        builder.HasOne(x => x.DiaryEntry)
            .WithOne(d => d.Lesson)
            .HasForeignKey<Lesson>(x => x.DiaryEntryId);

        builder.OwnsOne(x => x.LessonContents, configBuilder =>
        {
            configBuilder.ToJson();
        });
    }
}