﻿// <auto-generated />
using System;
using Microgreens.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Microgreens.Migrations
{
    [DbContext(typeof(ProductsDbContext))]
    partial class VisitorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Microgreens.Models.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateIn");

                    b.Property<DateTime>("DateOut");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("ShippingPrice");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Microgreens.Models.SowRatesL", b =>
                {
                    b.Property<int>("SowRatesId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("CostPerTray");

                    b.Property<DateTime>("DateIn");

                    b.Property<DateTime>("DateOut");

                    b.Property<int>("ProductsId");

                    b.Property<decimal>("SowWeight");

                    b.Property<int>("TraysPerPack");

                    b.Property<int?>("YieldId");

                    b.HasKey("SowRatesId");

                    b.HasIndex("ProductsId")
                        .IsUnique();

                    b.HasIndex("YieldId");

                    b.ToTable("SowRatesL");
                });

            modelBuilder.Entity("Microgreens.Models.Yields", b =>
                {
                    b.Property<int>("YieldId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("CostPerTray");

                    b.Property<DateTime>("DateIn");

                    b.Property<DateTime>("DateOut");

                    b.Property<int>("ProductsId");

                    b.Property<decimal>("Yield");

                    b.HasKey("YieldId");

                    b.HasIndex("ProductsId")
                        .IsUnique();

                    b.ToTable("Yields");
                });

            modelBuilder.Entity("Microgreens.Models.SowRatesL", b =>
                {
                    b.HasOne("Microgreens.Models.Products", "Product")
                        .WithOne("SowRates")
                        .HasForeignKey("Microgreens.Models.SowRatesL", "ProductsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microgreens.Models.Yields", "Yield")
                        .WithMany()
                        .HasForeignKey("YieldId");
                });

            modelBuilder.Entity("Microgreens.Models.Yields", b =>
                {
                    b.HasOne("Microgreens.Models.Products", "Product")
                        .WithOne("Yield")
                        .HasForeignKey("Microgreens.Models.Yields", "ProductsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
