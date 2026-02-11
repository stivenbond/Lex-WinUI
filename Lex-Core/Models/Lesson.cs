using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json.Serialization;

namespace Lex_Core.Models;

/// <summary>
/// Specifies the type of content within a lesson block.
/// </summary>
public enum BlockType
{
    /// <summary>
    /// A block containing formatted text.
    /// </summary>
    Text = 1,

    /// <summary>
    /// A block containing an attachment reference.
    /// </summary>
    Attachment = 2
}

/// <summary>
/// Specifies the formatting type for text blocks.
/// </summary>
public enum TextType
{
    /// <summary>
    /// Normal plain text.
    /// </summary>
    PlainText = 1,

    /// <summary>
    /// A structural heading.
    /// </summary>
    Heading = 2,

    /// <summary>
    /// A bulleted list.
    /// </summary>
    UnorderedList = 3,

    /// <summary>
    /// A numbered list.
    /// </summary>
    OrderedList = 4,
}

/// <summary>
/// Specifies the type of an attachment.
/// </summary>
public enum AttachmentType
{
    /// <summary>
    /// An image file.
    /// </summary>
    Image = 1,

    /// <summary>
    /// A video file.
    /// </summary>
    Video = 2
}

/// <summary>
/// Represents an educational lesson containing instructional content.
/// </summary>
public class Lesson
{
    /// <summary>
    /// Gets or sets the unique identifier for the lesson.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the lesson.
    /// </summary>
    public string? Title { get; set; }
    

    /// <summary>
    /// Gets or sets the collection of content blocks that make up the lesson.
    /// </summary>
    public List<ContentBlock>? LessonContents { get; set; }

    /// <summary>
    /// Gets or sets the foreign key for the associated subject.
    /// </summary>
    public int SubjectId { get; set; }

    /// <summary>
    /// Gets or sets the subject this lesson belongs to.
    /// </summary>
    public Subject Subject { get; set; }
    
    /// <summary>
    /// Gets or sets the foreign key for the associated diary entry.
    /// </summary>
    public int DiaryEntryId { get; set; }

    /// <summary>
    /// Gets or sets the diary entry that holds additional metadata for this lesson.
    /// </summary>
    public DiaryEntry DiaryEntry { get; set; }

    /// <summary>
    /// Gets or sets the foreign key for the next lesson to be taught.
    /// </summary>
    public int? NextLessonId { get; set; }

    /// <summary>
    /// Gets or sets the next lesson to be taught after this one.
    /// </summary>
    public Lesson? NextLesson { get; set; }

    /// <summary>
    /// Gets or sets the previous lesson that leads to this one.
    /// </summary>
    public Lesson? PreviousLesson { get; set; }
}

/// <summary>
/// An abstract base class for different types of content within a lesson.
/// </summary>
[JsonPolymorphic(TypeDiscriminatorPropertyName =  "Type")]
[JsonDerivedType(typeof(TextBlock),typeDiscriminator: (int)BlockType.Text)]
[JsonDerivedType(typeof(AttachmentBlock),typeDiscriminator: (int)BlockType.Attachment)]
public abstract class ContentBlock
{
    /// <summary>
    /// Gets or sets the unique identifier for the block.
    /// </summary>
    public int BlockId { get; set; }

    /// <summary>
    /// Gets or sets the type of the content block.
    /// </summary>
    public BlockType Type { get; set; }
}

/// <summary>
/// A content block that contains formatted text content.
/// </summary>
public class TextBlock : ContentBlock
{
    /// <summary>
    /// Gets or sets the formatting style of the text.
    /// </summary>
    public TextType Formatting { get; set; }

    /// <summary>
    /// Gets or sets the actual text content.
    /// </summary>
    public string? Content { get; set; }
}

/// <summary>
/// A content block that references an external or internal attachment.
/// </summary>
public class AttachmentBlock : ContentBlock
{
    /// <summary>
    /// Gets or sets the kind of attachment.
    /// </summary>
    public AttachmentType Kind { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the referenced attachment.
    /// </summary>
    public int AttachmentId { get; set; }
}

/// <summary>
/// Configures the entity framework mapping for the <see cref="Lesson"/> model.
/// </summary>
public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    /// <summary>
    /// Configures the properties and relationships for the <see cref="Lesson"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity.</param>
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

        // Next Lesson Self-Referencing Relationship (1-to-1)
        builder.HasOne(x => x.NextLesson)
            .WithOne(x => x.PreviousLesson)
            .HasForeignKey<Lesson>(x => x.NextLessonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.OwnsOne(x => x.LessonContents, configBuilder =>
        {
            configBuilder.ToJson();
        });
    }
}