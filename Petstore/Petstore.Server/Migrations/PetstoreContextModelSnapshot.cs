﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Petstore.Server.Data;

#nullable disable

namespace Petstore.Server.Migrations
{
    [DbContext(typeof(PetstoreContext))]
    partial class PetstoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Petstore.Server.Models.Pet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pets");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Buddy",
                            Status = "available"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Max",
                            Status = "pending"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Bella",
                            Status = "sold"
                        });
                });

            modelBuilder.Entity("Petstore.Server.Models.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PetId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Friendly"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Playful"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Aggressive"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Quiet"
                        });
                });

            modelBuilder.Entity("Petstore.Server.Models.Tag", b =>
                {
                    b.HasOne("Petstore.Server.Models.Pet", null)
                        .WithMany("Tags")
                        .HasForeignKey("PetId");
                });

            modelBuilder.Entity("Petstore.Server.Models.Pet", b =>
                {
                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
