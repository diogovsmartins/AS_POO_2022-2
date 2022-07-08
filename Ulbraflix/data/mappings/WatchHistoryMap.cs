using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ulbraflix.domain.entities;
using Ulbraflix.entities;

namespace Ulbraflix.data.mappings;

public class WatchHistoryMap : IEntityTypeConfiguration<WatchHistory>
{
    public void Configure(EntityTypeBuilder<WatchHistory> builder)
    {
        builder.ToTable("watch_history");
        
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("id");
    }
}