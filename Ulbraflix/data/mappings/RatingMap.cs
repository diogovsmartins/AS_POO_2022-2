using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ulbraflix.domain.entities;
using Ulbraflix.entities;

namespace Ulbraflix.data.mappings;

public class RatingMap : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder.ToTable("rating");
        
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("id");

        builder.Property(e => e.RatingValue)
            .HasColumnName("rating_value");
    }
}