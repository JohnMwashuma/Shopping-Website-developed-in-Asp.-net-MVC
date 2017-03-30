using System.ComponentModel.DataAnnotations;

namespace GrandLabFixers.Models
{
    public class Salutation
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}