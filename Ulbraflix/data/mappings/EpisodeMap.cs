using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ulbraflix.domain.entities;
using Ulbraflix.entities;

namespace Ulbraflix.data.mappings;

public class EpisodeMap : IEntityTypeConfiguration<Episode>
{
    public void Configure(EntityTypeBuilder<Episode> builder)
    {
        builder.ToTable("episode");
        
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("id");
        
        builder.Property(e => e.Duration)
            .HasColumnName("duration");

        builder.Property(e => e.LastMinuteWatched)
            .HasColumnName("last_minute_watched");
        
        builder.Property(e => e.Sinopsis)
            .HasColumnName("sinopsis")
            .HasMaxLength(256);
    }
}