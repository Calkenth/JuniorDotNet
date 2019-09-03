using System;
using System.ComponentModel.DataAnnotations;

namespace JuniorDotNet.Models
{
    public class Product
    {
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must have at least 1 character, maximum of 100.")]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public Guid Id { get; set; }

        protected Product() { }
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
            Id = Guid.NewGuid();
        }
        protected Product(string name, decimal price, Guid id)
        {
            Name = name;
            Price = price;
        }
    }
}