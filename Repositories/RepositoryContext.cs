﻿using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Repositories
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
         : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
            .HasData(
                new Product() { ProductId = 1, ProductName = "Computer", Price = 10000 },
                new Product() { ProductId = 2, ProductName = "Keyboard", Price = 1000 },
                new Product() { ProductId = 3, ProductName = "Mouse", Price = 600 },
                new Product() { ProductId = 4, ProductName = "Monitor", Price = 6000 }
            );
        }
    }
}
