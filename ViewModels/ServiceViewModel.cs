using GrandLabFixers.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GrandLabFixers.ViewModels
{

    public class ServiceViewModel
    {
        public ApplicationDbContext Context;

        public ServiceViewModel()
        {
            Context = new ApplicationDbContext();
        }


        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Details { get; set; }

        public decimal? Price { get; set; }

        public byte[] Image { get; set; }

        public string Heading { get; set; }

        public int ServiceCategory { get; set; }

        public ServiceCategory ServiceCategoryName { get; set; }

        public IEnumerable<ServiceCategory> ServiceCategories { get; set; }

        public string Action
        {
            get
            {
                return (Id != 0) ? "UpdateService" : "CreateService";
            }

        }

        public decimal GetTotal(string categoryname)
        {
            decimal? total = decimal.Zero;
            total = (decimal?)(from cartItems in Context.Serviceses
                               where cartItems.ServiceCategory.Name == categoryname
                               select (int?)cartItems.ServiceCategory.ServiceCategoryId).Count();

            return total ?? decimal.Zero;
        }


        public void RemoveFromService(int id)
        {
            var serviceItem = Context.Serviceses.Single(
                 c => c.ServiceId == id);


            if (serviceItem != null)
            {
                Context.Serviceses.Remove(serviceItem);
                // Save changes
                Context.SaveChanges();
            }

        }
    }
}