using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using AssetTracking.Domain;



namespace AssetTracking.Data
{
    public class AssetTrackingContext : DbContext

    {

        public DbSet<Computer> Computer { get; set; }
        public DbSet<Phone> Phone { get; set; }
        //public DbSet<Office> Office { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Server = (localdb)\\mssqllocaldb; Database = AssetTrackingContext;");
        }

    }
}
