﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VineCar.AppDbContext;

#nullable disable

namespace VineCar.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20240130003013_new")]
    partial class @new
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("VineCar.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A BRAND THAT DOES IT ALL",
                            Name = "MERCEDES"
                        },
                        new
                        {
                            Id = 2,
                            Description = "A BRAND THAT HAS ALL THE REQUIREMENTS",
                            Name = "BMW"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A BRAND JUST FOR YOU",
                            Name = "HONDA"
                        },
                        new
                        {
                            Id = 4,
                            Description = "A BRAND THAT REPRESENTS",
                            Name = "TOYOTA"
                        });
                });

            modelBuilder.Entity("VineCar.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BrandId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("cars");

                    b.HasData(
                        new
                        {
                            Id = 100,
                            BrandId = 1,
                            Description = "A Car with essential requirements",
                            Name = "GLK350",
                            Price = 20000000m
                        },
                        new
                        {
                            Id = 101,
                            BrandId = 1,
                            Description = "Durable and efficient",
                            Name = "Mercedes100",
                            Price = 1500000m
                        },
                        new
                        {
                            Id = 102,
                            BrandId = 2,
                            Description = "A Car Known for its uniqueness",
                            Name = "X6",
                            Price = 19000000m
                        },
                        new
                        {
                            Id = 103,
                            BrandId = 2,
                            Description = "Exotic with distinct properties",
                            Name = "X7",
                            Price = 23000000m
                        },
                        new
                        {
                            Id = 104,
                            BrandId = 3,
                            Description = "A Car with essentials",
                            Name = "Honda200",
                            Price = 1000000m
                        },
                        new
                        {
                            Id = 105,
                            BrandId = 3,
                            Description = "A Car That is efficient and worthy",
                            Name = "Honda-Civic",
                            Price = 1500000m
                        },
                        new
                        {
                            Id = 106,
                            BrandId = 4,
                            Description = "A Car with Robust features",
                            Name = "Camry200",
                            Price = 0m
                        },
                        new
                        {
                            Id = 107,
                            BrandId = 4,
                            Description = "A Car with a pocket friendly price",
                            Name = "Corolla112",
                            Price = 900000m
                        });
                });

            modelBuilder.Entity("VineCar.Entities.Car", b =>
                {
                    b.HasOne("VineCar.Entities.Brand", "Brand")
                        .WithMany("Cars")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("VineCar.Entities.Brand", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
