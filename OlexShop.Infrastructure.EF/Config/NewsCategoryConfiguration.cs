using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlexShop.Core.Domain.Entities;

namespace OlexShop.Infrastructure.EF.Config
{
    public class NewsCategoryConfiguration : IEntityTypeConfiguration<NewsCategory>
    {
        public void Configure(EntityTypeBuilder<NewsCategory> builder)
        {
            builder.HasKey(a => a.CategoryId);
            builder.Property(a => a.CategoryName).HasColumnType("nvarchar(30)");
            builder.HasMany(a => a.News);
        }
    }
}
