using System;
using System.ComponentModel.DataAnnotations;

namespace GrandLabFixers.Models
{
    public class RequestQuote
    {
        [Key]
        public int QuoteId { get; set; }

        public int Id { get; set; }

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
        [StringLength(160)]
        public string Department { get; set; }


        [Required]
        [StringLength(70)]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
        ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(40)]
        public string City { get; set; }

        [Required]
        [StringLength(24)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(10)]
        public string PostalCode { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public Country Country { get; set; }

        [Required]
        public Salutation Salutation { get; set; }

        public virtual Product Product { get; set; }

        [Required]
        [StringLength(255)]
        public string Message { get; set; }

        public string ProductName { get; set; }
    }
}