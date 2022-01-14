using Microsoft.EntityFrameworkCore;

namespace BicycleShop.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Bicycle> Bicycles { get; set; }
        public DbSet<TypeBicycle> TypeBicycles { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
