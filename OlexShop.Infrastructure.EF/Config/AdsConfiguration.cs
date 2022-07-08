using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlexShop.Core.Domain.Entities;

namespace OlexShop.Infrastructure.EF.Config
{
    public class AdsConfiguration : IEntityTypeConfiguration<Ads>
    {
        public void Configure(EntityTypeBuilder<Ads> builder)
        {
            builder.HasKey(a => a.AdsId);
            builder.Property(a => a.ImagePath).HasColumnType("nvarchar(max)").IsRequired();
        }
    }
}
