using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace GrandLabFixers.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {


        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<RequestQuote> RequestQuotes { get; set; }
        public DbSet<Salutation> Salutations { get; set; }
        public DbSet<RequestService> RequestServices { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Services> Serviceses { get; set; }
        public DbSet<Minicategory> Minicategories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        //    this.Database.Connection.ConnectionString =
        //        "Data Source=DESKTOP-DBM3JBC; Initial Catalog=GrandLabFixers; User ID=sa; Password=6927mwashi;Integrated Security=False";
        //}

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                .HasRequired(a => a.Product)
                .WithMany()
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>()
                .HasRequired(a => a.Product)
                .WithMany()
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);

        }
    }
}