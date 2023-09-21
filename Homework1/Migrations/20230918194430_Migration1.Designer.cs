﻿// <auto-generated />
using Homework1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Homework1.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230918194430_Migration1")]
    partial class Migration1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Homework1.Entities.Buyer", b =>
                {
                    b.Property<int>("buyer_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("buyer_id"));

                    b.Property<string>("buyer_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("buyer_id");

                    b.ToTable("Buyer", "eBay");
                });

            modelBuilder.Entity("Homework1.Entities.Category", b =>
                {
                    b.Property<long>("category_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("category_id"));

                    b.Property<string>("category_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("category_id");

                    b.ToTable("Category", "eBay");
                });

            modelBuilder.Entity("Homework1.Entities.Order", b =>
                {
                    b.Property<long>("order_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("order_id"));

                    b.Property<int>("buyer_id")
                        .HasColumnType("integer");

                    b.Property<long>("price")
                        .HasColumnType("bigint");

                    b.Property<long>("product_id")
                        .HasColumnType("bigint");

                    b.HasKey("order_id");

                    b.HasIndex("buyer_id");

                    b.HasIndex("product_id");

                    b.ToTable("Order", "eBay");
                });

            modelBuilder.Entity("Homework1.Entities.Product", b =>
                {
                    b.Property<long>("product_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("product_id"));

                    b.Property<long>("category_id")
                        .HasColumnType("bigint");

                    b.Property<string>("product_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("salesman_id")
                        .HasColumnType("bigint");

                    b.HasKey("product_id");

                    b.HasIndex("category_id");

                    b.HasIndex("salesman_id");

                    b.ToTable("Product", "eBay");
                });

            modelBuilder.Entity("Homework1.Entities.Salesman", b =>
                {
                    b.Property<long>("salesman_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("salesman_id"));

                    b.Property<string>("salesman_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("salesman_id");

                    b.ToTable("Salesman", "eBay");
                });

            modelBuilder.Entity("Homework1.Entities.Order", b =>
                {
                    b.HasOne("Homework1.Entities.Buyer", "Buyer")
                        .WithMany("Orders")
                        .HasForeignKey("buyer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Homework1.Entities.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Homework1.Entities.Product", b =>
                {
                    b.HasOne("Homework1.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Homework1.Entities.Salesman", "Salesman")
                        .WithMany("Products")
                        .HasForeignKey("salesman_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Salesman");
                });

            modelBuilder.Entity("Homework1.Entities.Buyer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Homework1.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Homework1.Entities.Product", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Homework1.Entities.Salesman", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}