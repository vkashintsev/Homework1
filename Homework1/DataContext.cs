using Microsoft.EntityFrameworkCore;
using Homework1.Entities;

namespace Homework1
{
    public class DataContext : DbContext
    {
        public DbSet<Buyer> buyer { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<Salesman> salesman { get; set; }

        public DataContext()
        {
            Database.EnsureDeleted();

            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=pass;Database=eBay");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var e in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var fk in e.GetForeignKeys())
                {
                    fk.DeleteBehavior = DeleteBehavior.Restrict;
                }
            }
        }
    }
}
