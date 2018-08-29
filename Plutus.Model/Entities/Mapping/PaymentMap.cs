using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Plutus.Model.Entities.Mapping
{
    public class PaymentMap : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable(nameof(Payment));

            // Primary Key
            builder.HasKey(x => x.PaymentId);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(x => x.Color)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(x => x.Icon)
                .IsRequired()
                .IsUnicode(false);
        }
    }
}
