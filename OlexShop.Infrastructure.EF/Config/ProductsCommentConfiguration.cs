using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlexShop.Core.Domain.Entities;

namespace OlexShop.Infrastructure.EF.Config
{
    public class ProductsCommentConfiguration : IEntityTypeConfiguration<ProductsComment>
    {
        public void Configure(EntityTypeBuilder<ProductsComment> builder)
        {
            builder.HasKey(a => a.CommentId);
            builder.Property(a => a.Name).HasColumnType("nvarchar(60)").IsRequired();
            builder.Property(a => a.Email).HasColumnType("nvarchar(60)").IsRequired();
            builder.Property(a => a.CommentText).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(a => a.PubTime).HasColumnType("datetime");
            builder.HasOne(a => a.Products).WithMany().HasForeignKey(a => a.ProductId);
        }
    }
}
