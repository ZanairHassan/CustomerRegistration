using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CustomerRegistrationForm.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}