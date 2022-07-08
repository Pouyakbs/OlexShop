using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlexShop.Core.Domain.Entities;

namespace OlexShop.Infrastructure.EF.Config
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(a => a.ProductId);
            builder.Property(a => a.ProductId).ValueGeneratedOnAdd();
            builder.Property(a => a.ProductName).HasColumnType("nvarchar(60)").IsRequired();
            builder.Property(a => a.Brand).HasColumnType("nvarchar(60)").IsRequired();
            builder.Property(a => a.Color).HasColumnType("nvarchar(60)");
            builder.Property(a => a.Options).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(a => a.Description).HasColumnType("nvarchar(max)");
            builder.Property(a => a.PubDate).HasColumnType("datetime");
            builder.Property(a => a.Price).HasColumnType("float");
            builder.Property(a => a.Quantity).HasColumnType("int");
            builder.HasOne(a => a.Category).WithMany().HasForeignKey(a => a.CategoryId);
            builder.HasMany(a => a.Comments);
            builder.HasMany(a => a.CartLines);
            builder.HasMany(a => a.Images);
        }
    }
}
