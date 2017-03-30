using GrandLabFixers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GrandLabFixers.ViewModels
{
    public class RequestServiceForm : IDisposable
    {
        public ApplicationDbContext _Context;

        public RequestServiceForm()
        {
            _Context = new ApplicationDbContext();
        }
        public int ProductId { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }
        [Required]
        public byte[] Image { get; set; }
        [Required]
        public string Heading { get; set; }
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

        public int Country { get; set; }
        [Required]
        public IEnumerable<Country> Countries { get; set; }

        public Country CountryName { get; set; }

        public int Salutation { get; set; }
        [Required]
        public IEnumerable<Salutation> Salutations { get; set; }
        
        public IEnumerable<RequestService> RequestServices { get; set; }

        public Product Products { get; set; }
        [Required]
        public string Message { get; set; }

        public int SelectedServiceType { get; set; }

        
        public List<ServiceType> ServiceTypes { get; set; }

        public string OtherServiceType { get; set; }

        public ServiceType IsSelected { get; set; }

        public string ServiceName { get; set; }

        public void RemoveServiceItem(int id)
        {
            var serviceItem = _Context.RequestServices.Single(
                 c => c.ServiceId == id);


            if (serviceItem != null)
            {
                _Context.RequestServices.Remove(serviceItem);
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