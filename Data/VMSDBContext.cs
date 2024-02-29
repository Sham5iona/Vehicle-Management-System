using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;
using VMS_EntityFrameworkCore.Model;

namespace VMS_EntityFrameworkCore.Data
{
    internal class VMSDBContext : DbContext
    {
        private const string connection_string = "Server=ALEKS-PC\\SQLEXPRESS;Database=VMSDB;" +
                                           "Trusted_Connection=True;TrustServerCertificate=True;";
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connection_string);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasMany(c => c.Rentals).WithOne(r => r.Car);
            modelBuilder.Entity<Customer>().HasMany(c => c.Rentals).WithOne(r => r.Customer);
        }

    }
}
