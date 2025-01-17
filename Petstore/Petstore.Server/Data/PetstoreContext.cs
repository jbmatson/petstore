using Azure;
using Microsoft.EntityFrameworkCore;
using Petstore.Server.Models;

namespace Petstore.Server.Data
{
    public class PetstoreContext : DbContext
    {
        public PetstoreContext(DbContextOptions<PetstoreContext> options)
        : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>()
                .Property(p => p.Status)
                .HasConversion<string>(); // To ensure enums are stored as strings if using an enum type for Status

            modelBuilder.Entity<Pet>()
                .OwnsMany(p => p.PhotoUrls); // Configures PhotoUrls as a collection
        }
    }
}
