using System.ComponentModel.DataAnnotations;

namespace GrandLabFixers.Models
{
    public class Services
    {
        [Key]
        public int ServiceId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Details { get; set; }

        public decimal? Price { get; set; }

        [Required]
        public byte[] Image { get; set; }

        public ServiceCategory ServiceCategory { get; set; }
    }
}