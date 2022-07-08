using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ulbraflix.domain.entities;
using Ulbraflix.entities;
using Ulbraflix.entities.enums;

namespace Ulbraflix.data.mappings;

public class SubscriptionMap : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.ToTable("subscription");

        builder.Property(e => e.Id)
            .HasColumnName("id");
        
        builder.HasKey(e => e.Id);

        builder.Property(e => e.IsActive)
            .HasColumnName("is_active")
            .HasColumnType("SMALLINT");
        
        builder.Property(e => e.PaymentMethod)
            .HasColumnName("payment_method")
            .HasMaxLength(80);

        builder.Property(e => e.PaymentValue)
            .HasColumnName("payment_value");

        builder.Property(e => e.SubscriptionType)
            .HasColumnName("subscription_type")
            .HasConversion(
                v => v.ToString(),
                v => (SubscriptionEnum) 
                    Enum.Parse(typeof(SubscriptionEnum), v));
    }
}