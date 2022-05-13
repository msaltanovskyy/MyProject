using Microsoft.EntityFrameworkCore;
using Observatory.Models;

namespace Observatory.Data
{
    public class ObservatoryDbContext : DbContext
    {
        public ObservatoryDbContext(DbContextOptions<ObservatoryDbContext> options) : base(options)
        {

        }
        
        public ObservatoryDbContext()
        {

        }
        public virtual DbSet<Area> area { get; set; }
        public virtual DbSet<Planets> planets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            base.OnModelCreating(modelBuilder);

        }

    }
}
