using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlexShop.Core.Domain.Entities;

namespace OlexShop.Infrastructure.EF.Config
{
    public class AdminAuthenticationConfiguration : IEntityTypeConfiguration<AdminAuthentication>
    {
        public void Configure(EntityTypeBuilder<AdminAuthentication> builder)
        {
            builder.HasKey(a => a.UsernameId);
            builder.Property(a => a.Username).HasColumnType("nvarchar(60)").IsRequired();
            builder.Property(a => a.Password).HasColumnType("nvarchar(20)").IsRequired();
        }
    }
}
