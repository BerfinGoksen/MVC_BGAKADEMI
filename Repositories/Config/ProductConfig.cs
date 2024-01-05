using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repositories.Config;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price).IsRequired();

            builder.HasData(
             new Product() { ProductId = 1, ImageUrl = "/images/kediş.jpg", CategoryId = 2, ProductName = "Computer", Price = 10000, ShowCase = false },
             new Product() { ProductId = 2, ImageUrl = "/images/kediş.jpg", CategoryId = 2, ProductName = "Keyboard", Price = 1000, ShowCase = false },
             new Product() { ProductId = 3, ImageUrl = "/images/kediş.jpg", CategoryId = 1, ProductName = "Mouse", Price = 600, ShowCase = false },
             new Product() { ProductId = 4, ImageUrl = "/images/kediş.jpg", CategoryId = 1, ProductName = "Monitor", Price = 6000, ShowCase = false },
             new Product() { ProductId = 5, ImageUrl = "/images/kediş.jpg", CategoryId = 2, ProductName = "Earphones", Price = 10000, ShowCase = false },
             new Product() { ProductId = 6, ImageUrl = "/images/kediş.jpg", CategoryId = 2, ProductName = "Berfin", Price = 1000, ShowCase = true },
             new Product() { ProductId = 7, ImageUrl = "/images/kediş.jpg", CategoryId = 1, ProductName = "Beyza", Price = 600, ShowCase = true },
             new Product() { ProductId = 8, ImageUrl = "/images/kediş.jpg", CategoryId = 1, ProductName = "İlker", Price = 6000, ShowCase = true }
            );
        }
    }
}