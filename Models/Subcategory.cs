using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrandLabFixers.Models
{
    public class Subcategory
    {
        public Category Category { get; set; }

        public Minicategory Minicategory { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte CategoryId { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte MinicategoryId { get; set; }
    }
}