using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lex_Core.Models;

/// <summary>
/// Represents a file attachment, such as an image or video, stored locally or on the web.
/// </summary>
public class Attachment
{
    /// <summary>
    /// Gets or sets the unique identifier for the attachment.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the display name or label of the attachment.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the URI (web URL or local path) where the attachment is located.
    /// </summary>
    public string Uri { get; set; } = string.Empty;
}

/// <summary>
/// Configures the entity framework mapping for the <see cref="Attachment"/> model.
/// </summary>
public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
{
    /// <summary>
    /// Configures the properties and relationships for the <see cref="Attachment"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity.</param>
    public void Configure(EntityTypeBuilder<Attachment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Uri).IsRequired();
    }
}
