using CRMSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRMSystem.Data
{
    public class CRMDbContext : IdentityDbContext<User>
    {
        public CRMDbContext(DbContextOptions<CRMDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Customer>()
                .HasMany(x => x.SalledProducts);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
