using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Plutus.Model.Entities.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category));

            // Primary Key
            builder.HasKey(x => x.CategoryId);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(x => x.Icon)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(x => x.Color)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(x => x.TypeId)
                .IsRequired();
        }
    }
}
