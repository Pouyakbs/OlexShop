using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlexShop.Core.Domain.Entities;

namespace OlexShop.Infrastructure.EF.Config
{
    public class ProductsCategoryConfiguration : IEntityTypeConfiguration<ProductsCategory>
    {
        public void Configure(EntityTypeBuilder<ProductsCategory> builder)
        {
            builder.HasKey(a => a.CategoryId);
            builder.Property(a => a.CategoryName).HasColumnType("nvarchar(60)").IsRequired();
            builder.HasMany(a => a.Products);
        }
    }
}
