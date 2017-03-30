using System.ComponentModel.DataAnnotations;

namespace GrandLabFixers.Models
{
    public class OrderDetail
    {   
        [Key]
        public int OrderDetailId { get; set; }

        public int Id { get; set; }

        public ApplicationUser UserName { get; set; }

        public string ClientName { get; set; }

       public int Quantity { get; set; }

        public decimal? UnitPrice { get; set; }

       public virtual Order Order { get; set; }
    }
}