using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrandLabFixers.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public ApplicationUser UserName { get; set; }

        public string ClientName { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

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

        public OrderDetail OrderDetail { get; set; }

        public Product  Product { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public int Quantity { get; set; }

        [Required]
        public Country Country { get; set; }
    }
}