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


            // TODO: Ignore PhotoUrls for now - come back to it later

            //modelBuilder.Entity<Pet>(entity =>
            //{
            //    entity.OwnsMany(p => p.PhotoUrls, photo =>
            //    {
            //        photo.WithOwner();
            //    });
            //});

            // Seed data for Tags
            modelBuilder.Entity<Tag>().HasData(
                new Tag { Id = 1, Name = "Friendly" },
                new Tag { Id = 2, Name = "Playful" },
                new Tag { Id = 3, Name = "Aggressive" },
                new Tag { Id = 4, Name = "Quiet" }
            );

            // Seed data for Pets
            modelBuilder.Entity<Pet>().HasData(
                new Pet { Id = 1, Name = "Buddy", Status = "available" },
                new Pet { Id = 2, Name = "Max", Status = "pending" },
                new Pet { Id = 3, Name = "Bella", Status = "sold" }
            );
        }
    }
}
