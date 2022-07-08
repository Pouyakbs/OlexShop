using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlexShop.Core.Domain.Entities;

namespace OlexShop.Infrastructure.EF.Config
{
    public class ProductImagesConfiguration : IEntityTypeConfiguration<ProductImages>
    {
        public void Configure(EntityTypeBuilder<ProductImages> builder)
        {
            builder.HasKey(a => a.ImageId);
            builder.Property(a => a.ProductImage).HasColumnType("nvarchar(max)").IsRequired();
            builder.Ignore(a => a.Images);
            builder.HasOne(a => a.Products).WithMany().HasForeignKey(a => a.ProductId);
        }
    }
}
