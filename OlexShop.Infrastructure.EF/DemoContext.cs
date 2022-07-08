using Microsoft.EntityFrameworkCore;
using OlexShop.Core.Domain.Entities;
using System;
using System.Reflection;

namespace OlexShop.Infrastructure.EF
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductsCategory> ProductsCategory { get; set; }
        public DbSet<ProductsComment> ProductsComment { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsCategory> NewsCategory { get; set; }
        public DbSet<NewsComment> NewsComment { get; set; }
        public DbSet<UserAuthentication> UserAuthentication { get; set; }
        public DbSet<AdminAuthentication> AdminAuthentication { get; set; }
        public DbSet<Ads> Ads { get; set; }
    }
}
