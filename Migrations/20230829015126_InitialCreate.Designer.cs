﻿// <auto-generated />
using System;
using BangazonBE_SB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BangazonBE_SB.Migrations
{
    [DbContext(typeof(BangazonDBContext))]
    [Migration("20230829015126_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BangazonBE_SB.Models.Orders", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderId"));

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            StatusId = 1,
                            UserId = 1
                        },
                        new
                        {
                            OrderId = 2,
                            StatusId = 2,
                            UserId = 2
                        },
                        new
                        {
                            OrderId = 3,
                            StatusId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("BangazonBE_SB.Models.OrderStatuses", b =>
                {
                    b.Property<int>("OrderStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderStatusId"));

                    b.Property<string>("OrderStatus")
                        .HasColumnType("text");

                    b.HasKey("OrderStatusId");

                    b.ToTable("OrderStatuses");

                    b.HasData(
                        new
                        {
                            OrderStatusId = 1,
                            OrderStatus = "Ordered"
                        },
                        new
                        {
                            OrderStatusId = 2,
                            OrderStatus = "Shipped"
                        },
                        new
                        {
                            OrderStatusId = 3,
                            OrderStatus = "Completed"
                        },
                        new
                        {
                            OrderStatusId = 4,
                            OrderStatus = "Cancelled"
                        });
                });

            modelBuilder.Entity("BangazonBE_SB.Models.PaymentTypes", b =>
                {
                    b.Property<int>("PaymentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PaymentTypeId"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("Users_PaymentTypesUserPaymentTypeId")
                        .HasColumnType("integer");

                    b.HasKey("PaymentTypeId");

                    b.HasIndex("Users_PaymentTypesUserPaymentTypeId");

                    b.ToTable("PaymentTypes");

                    b.HasData(
                        new
                        {
                            PaymentTypeId = 1,
                            Name = "Credit Card"
                        },
                        new
                        {
                            PaymentTypeId = 2,
                            Name = "PayPal"
                        },
                        new
                        {
                            PaymentTypeId = 3,
                            Name = "Cash"
                        });
                });

            modelBuilder.Entity("BangazonBE_SB.Models.ProductCategories", b =>
                {
                    b.Property<int>("ProductCatagoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductCatagoryId"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ProductCatagoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            ProductCatagoryId = 1,
                            Name = "Electronics"
                        },
                        new
                        {
                            ProductCatagoryId = 2,
                            Name = "Clothing"
                        },
                        new
                        {
                            ProductCatagoryId = 3,
                            Name = "Furniture"
                        });
                });

            modelBuilder.Entity("BangazonBE_SB.Models.Products", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Name = "Product A",
                            Price = 10.99m,
                            ProductCategoryId = 1,
                            UserId = 1
                        },
                        new
                        {
                            ProductId = 2,
                            Name = "Product B",
                            Price = 20.49m,
                            ProductCategoryId = 2,
                            UserId = 2
                        },
                        new
                        {
                            ProductId = 3,
                            Name = "Product C",
                            Price = 5.99m,
                            ProductCategoryId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("BangazonBE_SB.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<bool>("IsSeller")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NickName")
                        .HasColumnType("text");

                    b.Property<DateTime>("TimeCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("Users_PaymentTypesUserPaymentTypeId")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.HasIndex("Users_PaymentTypesUserPaymentTypeId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            IsSeller = true,
                            Name = "Jack Smith",
                            NickName = "JSmith",
                            TimeCreated = new DateTime(2023, 8, 28, 21, 51, 26, 237, DateTimeKind.Local).AddTicks(2775)
                        },
                        new
                        {
                            UserId = 2,
                            IsSeller = false,
                            Name = "Chris Lee",
                            NickName = "CLee",
                            TimeCreated = new DateTime(2023, 8, 28, 21, 51, 26, 237, DateTimeKind.Local).AddTicks(2809)
                        },
                        new
                        {
                            UserId = 3,
                            IsSeller = false,
                            Name = "Steve Wilson",
                            NickName = "SWilson",
                            TimeCreated = new DateTime(2023, 8, 28, 21, 51, 26, 237, DateTimeKind.Local).AddTicks(2811)
                        });
                });

            modelBuilder.Entity("BangazonBE_SB.Models.Users_PaymentTypes", b =>
                {
                    b.Property<int>("UserPaymentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserPaymentTypeId"));

                    b.Property<int>("PaymentId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("UserPaymentTypeId");

                    b.ToTable("UserPaymentTypes");

                    b.HasData(
                        new
                        {
                            UserPaymentTypeId = 1,
                            PaymentId = 1,
                            UserId = 1
                        },
                        new
                        {
                            UserPaymentTypeId = 2,
                            PaymentId = 2,
                            UserId = 2
                        },
                        new
                        {
                            UserPaymentTypeId = 3,
                            PaymentId = 3,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("OrdersProducts", b =>
                {
                    b.Property<int>("OrdersOrderId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductsProductId")
                        .HasColumnType("integer");

                    b.HasKey("OrdersOrderId", "ProductsProductId");

                    b.HasIndex("ProductsProductId");

                    b.ToTable("OrdersProducts");
                });

            modelBuilder.Entity("BangazonBE_SB.Models.PaymentTypes", b =>
                {
                    b.HasOne("BangazonBE_SB.Models.Users_PaymentTypes", null)
                        .WithMany("PaymentTypes")
                        .HasForeignKey("Users_PaymentTypesUserPaymentTypeId");
                });

            modelBuilder.Entity("BangazonBE_SB.Models.User", b =>
                {
                    b.HasOne("BangazonBE_SB.Models.Users_PaymentTypes", null)
                        .WithMany("Users")
                        .HasForeignKey("Users_PaymentTypesUserPaymentTypeId");
                });

            modelBuilder.Entity("OrdersProducts", b =>
                {
                    b.HasOne("BangazonBE_SB.Models.Orders", null)
                        .WithMany()
                        .HasForeignKey("OrdersOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BangazonBE_SB.Models.Products", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BangazonBE_SB.Models.Users_PaymentTypes", b =>
                {
                    b.Navigation("PaymentTypes");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
