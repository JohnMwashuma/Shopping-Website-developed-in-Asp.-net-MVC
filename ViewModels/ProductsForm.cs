using GrandLabFixers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GrandLabFixers.ViewModels
{
    public class ProductsForm : IDisposable
    {
        public ApplicationDbContext Context;

        public ProductsForm()
        {
            Context = new ApplicationDbContext();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Details { get; set; }


        public decimal? Price { get; set; }

        public int Quantity { get; set; }

        public bool IsFeatured { get; set; }

        public byte[] Image { get; set; }

        public Order Order { get; set; }

        public List<Product> Products { get; set; }

        public Product ProductsList { get; set; }

        public IEnumerable<Product> Product { get; set; }

        public int Category { get; set; }

        public Category CategoryName { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                return (Id != 0) ? "Update" : "Create";
            }

        }


        public void RemoveFromProduct(int id)
        {
            var productItem = Context.Products.Single(
                 c => c.Id == id);


            if (productItem != null)
            {
                Context.Products.Remove(productItem);
                // Save changes
                Context.SaveChanges();
            }

        }

        public decimal GetTotal(string categoryname)
        {
            decimal? total = decimal.Zero;
            total = (decimal?)(from cartItems in Context.Products
                               where cartItems.Category.Name == categoryname
                               select (int?)cartItems.Category.Id).Count();

            return total ?? decimal.Zero;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}