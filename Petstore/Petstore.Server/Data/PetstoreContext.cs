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

        // Parameterless constructor for design-time tools
        public PetstoreContext() : base(new DbContextOptionsBuilder<PetstoreContext>()
            .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PetstoreDb;Trusted_Connection=True;")
            .Options)
        {
        }


        public DbSet<Pet> Pets { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>()
                .Property(p => p.Status)
                .HasConversion<string>(); // To ensure enums are stored as strings if using an enum type for Status

            //modelBuilder.Entity<Pet>(entity =>
            //{
            //    entity.OwnsMany(p => p.PhotoUrls, photo =>
            //    {
            //        photo.WithOwner();
            //    });
            //});
        }
    }
}
