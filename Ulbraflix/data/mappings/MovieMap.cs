using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ulbraflix.domain.entities;
using Ulbraflix.entities;

namespace Ulbraflix.data.mappings;

public class MovieMap : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("movie");

        builder.Property(e => e.Id)
            .HasColumnName("id");
            

        builder.Property(e => e.Duration)
            .HasColumnName("duration");

        builder.Property(e => e.LastMinuteWatched)
            .HasColumnName("last_minute_watched");

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