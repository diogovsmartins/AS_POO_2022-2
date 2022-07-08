using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ulbraflix.domain.entities;
using Ulbraflix.entities;

namespace Ulbraflix.data.mappings;

public class SerieMap : IEntityTypeConfiguration<Serie>
{
    public void Configure(EntityTypeBuilder<Serie> builder)
    {
        builder.ToTable("serie");

        builder.Property(e => e.Id)
            .HasColumnName("id");

        builder.Property(e => e.Name)
            .HasColumnName("name")
            .HasMaxLength(100);

        builder.Property(e => e.Sinopsis)
            .HasColumnName("sinopsis")
            .HasMaxLength(256);

        builder.Property(e => e.IsWatched)
            .HasColumnName("is_watched")
            .HasColumnType("SMALLINT");
    }
}