﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaLoco.Data;

namespace PizzaLoco.Migrations
{
    [DbContext(typeof(PizzaLocoContext))]
    [Migration("20210106004242_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PizzaLoco.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("PizzaLoco.Models.Pizza", b =>
                {
                    b.Property<int>("PizzaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6, 2)");

                    b.HasKey("PizzaId");

                    b.ToTable("Pizza");
                });

            modelBuilder.Entity("PizzaLoco.Models.PizzaBase", b =>
                {
                    b.Property<int>("PizzaBaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PizzaBaseId");

                    b.ToTable("PizzaBase");
                });

            modelBuilder.Entity("PizzaLoco.Models.PizzaOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PizzaBaseId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaSizeId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("PizzaBaseId");

                    b.HasIndex("PizzaId");

                    b.HasIndex("PizzaSizeId");

                    b.ToTable("PizzaOrder");
                });

            modelBuilder.Entity("PizzaLoco.Models.PizzaSize", b =>
                {
                    b.Property<int>("PizzaSizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("PizzaSizeId");

                    b.ToTable("PizzaSize");
                });

            modelBuilder.Entity("PizzaLoco.Models.PizzaOrder", b =>
                {
                    b.HasOne("PizzaLoco.Models.Client", "Client")
                        .WithMany("PizzaOrders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaLoco.Models.PizzaBase", "PizzaBase")
                        .WithMany("PizzaOrders")
                        .HasForeignKey("PizzaBaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaLoco.Models.Pizza", "Pizza")
                        .WithMany("PizzaOrders")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaLoco.Models.PizzaSize", "PizzaSize")
                        .WithMany("PizzaOrders")
                        .HasForeignKey("PizzaSizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
