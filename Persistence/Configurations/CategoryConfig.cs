using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(e => e.CategoryId).HasColumnName("CategoryID");
            builder.Property(e => e.CategoryName)
            .IsRequired()
            .HasMaxLength(30);
            builder.Property(e => e.Picture).HasColumnType("image");
            builder.Property(e => e.Description).HasColumnType("ntext");
        }
    }
}
