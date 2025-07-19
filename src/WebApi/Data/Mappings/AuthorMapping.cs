using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VirtualBookstore.WebApi.Authors;
using VirtualBookstore.WebApi.Commons.Types;

namespace VirtualBookstore.WebApi.Data.Mappings;

internal class AuthorMapping : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("authors");

        builder.HasKey(x => x.Id);

        builder.HasAlternateKey(x => x.Email);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnType("UUID")
            .HasConversion(id => id.Value, valor => AuthorId.From(valor));

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(100)
            .HasConversion(name => name.Value, valor => Name.From(valor));

        builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(255)
            .HasConversion(email => email.Value, valor => Email.From(valor));

        builder.Property(x => x.Description)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(400)
            .HasConversion(description => description.Value, valor => Description.From(valor));

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnType("TIMESTAMPTZ");
    }
}
