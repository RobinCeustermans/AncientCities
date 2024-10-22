﻿// <auto-generated />
using System;
using AncientCities.Data.DbApplicationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AncientCities.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AncientCities.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Defunct")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EraCreated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EraDefunct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartOf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Population")
                        .HasColumnType("int");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(753, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Greatest city of its time",
                            EraCreated = "BC",
                            Name = "Rome",
                            PartOf = "Roman Empire (after Republic, Kingdom)",
                            Population = 450000,
                            TypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(859, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "now named Veliky Novgorod, part of Russia",
                            EraCreated = "AD",
                            Name = "Novgorod",
                            PartOf = "Novgorod republic",
                            Population = 40000,
                            TypeId = 4
                        });
                });

            modelBuilder.Entity("AncientCities.Models.CityImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("CityImages");
                });

            modelBuilder.Entity("AncientCities.Models.CityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Types");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Capital"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Regional capital"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Regular city"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Trade hub"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Port"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Town"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Village"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Hamlet"
                        });
                });

            modelBuilder.Entity("AncientCities.Models.City", b =>
                {
                    b.HasOne("AncientCities.Models.CityType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("AncientCities.Models.CityImage", b =>
                {
                    b.HasOne("AncientCities.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });
#pragma warning restore 612, 618
        }
    }
}
