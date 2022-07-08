using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlexShop.Core.Domain.Entities;
using System.Collections.Generic;
using System.Text;

namespace OlexShop.Infrastructure.EF.Config
{
    public class NewsConfiguration:IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasKey(a => a.NewsId);
            builder.Property(a => a.NewsTitle).HasColumnType("nvarchar(900)").IsRequired();
            builder.Property(a => a.NewsSummary).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(a => a.NewsText).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(a => a.NewsImages).HasColumnType("nvarchar(max)");
            builder.Property(a => a.PubDate).HasColumnType("datetime");
            builder.Ignore(a => a.Images);
            builder.HasOne(a => a.Category).WithMany().HasForeignKey(a => a.CategoryId);
            builder.HasMany(a => a.Comments);

        }
    }
}
