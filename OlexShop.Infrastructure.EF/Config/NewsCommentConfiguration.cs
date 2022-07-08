using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlexShop.Core.Domain.Entities;

namespace OlexShop.Infrastructure.EF.Config
{
    public class NewsCommentConfiguration : IEntityTypeConfiguration<NewsComment>
    {
        public void Configure(EntityTypeBuilder<NewsComment> builder)
        {
            builder.HasKey(a => a.CommentId);
            builder.Property(a => a.Name).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(a => a.Email).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(a => a.CommentText).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(a => a.PubTime).HasColumnType("datetime");
            builder.HasOne(a => a.News).WithMany().HasForeignKey(a=>a.NewsId);
        }
    }
}
