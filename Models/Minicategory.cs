using System.ComponentModel.DataAnnotations;

namespace GrandLabFixers.Models
{
    public class Minicategory
    {
        public byte MinicategoryId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

    }
}