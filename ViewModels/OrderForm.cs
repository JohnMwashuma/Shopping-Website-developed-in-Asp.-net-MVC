using GrandLabFixers.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GrandLabFixers.ViewModels
{
    public class OrderForm
    {
        public ApplicationDbContext Context;

        public OrderForm()
        {
            Context = new ApplicationDbContext();
        }

        [Required]
        [StringLength(160)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(160)]
        public string LastName { get; set; }

        [Required]
        [StringLength(160)]
        public string Company { get; set; }

        [Required]
        [StringLength(70)]
        public string Address { get; set; }

        [Required]
        [StringLength(40)]
        public string City { get; set; }

        [Required]
        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(24)]
        public string AdditionalPhone { get; set; }


        [ScaffoldColumn(false)]
        public decimal Total { get; set; }

        public List<Product> Products { get; set; }

        public List<Order> Orders { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public OrderDetail OrderDetail { get; set; }

        public Product Product { get; set; }

        public int Country { get; set; }

        public int Quantity { get; set; }

        public IEnumerable<Country> Countries { get; set; }

        public void RemoveFromOrder(int id)
        {
            var orderItem = Context.Orders.Single(
                 c => c.Id == id);


            if (orderItem != null)
            {
                Context.Orders.Remove(orderItem);
                // Save changes
                Context.SaveChanges();
            }

        }
    }
}