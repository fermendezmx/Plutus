using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Plutus.Model.Entities.Mapping
{
    public class ReceiptMap : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            builder.ToTable(nameof(Receipt));

            // Primary Key
            builder.HasKey(x => x.ReceiptId);

            builder.Property(x => x.TransactionDate)
                .IsRequired();

            builder.Property(x => x.Amount)
                .IsRequired();

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(x => x.CreatedDate)
                .IsRequired();

            builder.Property(x => x.ModifiedDate)
                .IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany(y => y.Receipt)
                .HasForeignKey(z => z.CategoryId);

            builder.HasOne(x => x.Payment)
                .WithMany(y => y.Receipt)
                .HasForeignKey(z => z.PaymentId);

            builder.HasOne(x => x.Account)
                .WithMany(y => y.Receipt)
                .HasForeignKey(z => z.AccountId);
        }
    }
}
