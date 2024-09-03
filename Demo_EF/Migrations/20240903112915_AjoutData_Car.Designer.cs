﻿// <auto-generated />
using System;
using Demo_EF.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Demo_EF.Migrations
{
    [DbContext(typeof(DemoDbContext))]
    [Migration("20240903112915_AjoutData_Car")]
    partial class AjoutData_Car
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Demo_EF.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasPrecision(9, 2)
                        .HasColumnType("decimal(9,2)");

                    b.Property<DateTime?>("RegistrationDate")
                        .HasColumnType("date");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Car");

                    b.ToTable("Vrouvoum", null, t =>
                        {
                            t.HasCheckConstraint("CK_Car__Price", "[Price] >= 0");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Model = "Samara",
                            Price = 199.99m,
                            RegistrationDate = new DateTime(1987, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            State = 1
                        },
                        new
                        {
                            Id = 2,
                            Model = "R8 Spyder",
                            Price = 1930.5m,
                            State = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
