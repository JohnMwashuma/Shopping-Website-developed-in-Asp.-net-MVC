using System.ComponentModel.DataAnnotations;

namespace GrandLabFixers.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Details { get; set; }

        public decimal? Price { get; set; }

        public int? Quantity { get; set; }

        public byte[] Image { get; set; }

        public bool IsFeatured { get; set; }

        public Order Order { get; set; }

        [Required]
        public Category Category { get; set; }

        public Minicategory Minicategory { get; set; }

        public Cart Cart { get; set; }
    }
}