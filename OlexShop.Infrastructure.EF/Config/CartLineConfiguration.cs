using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlexShop.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlexShop.Infrastructure.EF.Config
{
    class CartLineConfiguration : IEntityTypeConfiguration<CartLine>
    {
        public void Configure(EntityTypeBuilder<CartLine> builder)
        {
            builder.HasKey(a => a.CartLineId);
            builder.Property(a => a.Quantity).HasColumnType("int");
            builder.HasOne(a => a.Product).WithMany().HasForeignKey(a => a.ProductId);
        }
        
    }
}
