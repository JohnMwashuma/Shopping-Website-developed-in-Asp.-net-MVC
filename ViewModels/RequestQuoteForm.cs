using GrandLabFixers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GrandLabFixers.ViewModels
{
    public class RequestQuoteForm : IDisposable
    {
        public ApplicationDbContext _Context;

        public RequestQuoteForm()
        {
            _Context = new ApplicationDbContext();
        }
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
        ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public int Quantity { get; set; }


        public int Country { get; set; }

        [Required]
        public IEnumerable<Country> Countries { get; set; }


        public int Salutation { get; set; }

        [Required]
        public IEnumerable<Salutation> Salutations { get; set; }

        public List<RequestQuote> RequestQuotes { get; set; }

        public Product Products { get; set; }

        [Required]
        public string Message { get; set; }

        public string Heading { get; set; }

        public byte[] Image { get; set; }

        public string Institution { get; set; }

        public Country CountryName { get; set; }

        public DateTime RequestDate { get; set; }

        public List<Product> GetProducts()
        {
            return _Context.Products.ToList();
        }

        public void RemoveQuoteItem(int id)
        {
            var quoteItem = _Context.RequestQuotes.Single(
                 c => c.QuoteId == id);


            if (quoteItem != null)
            {
                _Context.RequestQuotes.Remove(quoteItem);
                // Save changes
                _Context.SaveChanges();
            }

        }

        public void Dispose()
        {
            if (_Context != null)
            {
                _Context.Dispose();
                _Context = null;
            }
        }
    }
}