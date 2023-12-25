using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; // EntityTypeBuilder'ı içeren namespace
using Entities.Models;

namespace Repositories.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);
            builder.Property(c => c.CategoryName).IsRequired();
            builder.HasData(
                new Category() { CategoryId = 1, CategoryName = "C#" },
                new Category() { CategoryId = 2, CategoryName = "PHP" }
            );
        }
    }
}