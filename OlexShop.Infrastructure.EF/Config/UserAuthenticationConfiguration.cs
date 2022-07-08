using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlexShop.Core.Domain.Entities;
using System;

namespace OlexShop.Infrastructure.EF.Config
{
    public class UserAuthenticationConfiguration : IEntityTypeConfiguration<UserAuthentication>
    {
        public void Configure(EntityTypeBuilder<UserAuthentication> builder)
        {
            builder.HasKey(a => a.UsernameId);
            builder.Property(a => a.Username).HasColumnType("nvarchar(60)").IsRequired();
            builder.Property(a => a.Password).HasColumnType("nvarchar(20)").IsRequired();
            builder.Property(a => a.ProfileImage).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(a => a.Email).HasColumnType("nvarchar(70)");
            builder.Ignore(a => a.Images);
        }
    }
}
