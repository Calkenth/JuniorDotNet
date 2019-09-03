using System;
using System.Collections.Generic;
using System.Linq;
using JuniorDotNet.Controllers;
using Microsoft.EntityFrameworkCore;

namespace JuniorDotNet.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCreateInputModel> NewProducts { get; set; }
        public IEnumerable<Product> GetAllProducts()
        {
            return Products.ToList();
        }
        public Product GetProduct(Guid id)
        {
            return Products.Find(id);
        }
    }
}