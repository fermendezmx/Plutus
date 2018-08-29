using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Plutus.Model.Entities.Mapping
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable(nameof(Account));

            // Primary Key
            builder.HasKey(x => x.AccountId);

            builder.Property(x => x.AccountId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(x => x.Picture)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(x => x.CreatedDate)
                .IsRequired();

            builder.Property(x => x.ModifiedDate)
                .IsRequired();
        }
    }
}
