﻿// <auto-generated />
using DRRestaurant.Infrastructure.Identity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DRRestaurant.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(RestaurantContext))]
    [Migration("20231113055212_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DRRestaurant.Core.Domain.Entities.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("QuantityOfPeople")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Dishes", (string)null);
                });

            modelBuilder.Entity("DRRestaurant.Core.Domain.Entities.DishCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("DishCategories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Entrada",
                            Status = true
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Plato fuerte",
                            Status = true
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Postre",
                            Status = true
                        },
                        new
                        {
                            Id = 4,
                            CategoryName = "Bebida",
                            Status = true
                        });
                });

            modelBuilder.Entity("DRRestaurant.Core.Domain.Entities.DishIngredients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    b.HasIndex("IngredientId");

                    b.ToTable("DishIngredients", (string)null);
                });

            modelBuilder.Entity("DRRestaurant.Core.Domain.Entities.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Ingredients", (string)null);
                });

            modelBuilder.Entity("DRRestaurant.Core.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<double>("SubTotal")
                        .HasColumnType("float");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TableId");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("DRRestaurant.Core.Domain.Entities.OrdersDishes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDishes", (string)null);
                });

            modelBuilder.Entity("DRRestaurant.Core.Domain.Entities.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantityOfPersonOntheTable")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("TableStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TableStatusId");

                    b.ToTable("Tables", (string)null);
                });

            modelBuilder.Entity("DRRestaurant.Core.Domain.Entities.TableStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("TableStatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TableStatus", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Status = true,
                            TableStatusName = "Disponible"
                        },
                        new
                        {
                            Id = 2,
                            Status = true,
                            TableStatusName = "en proceso de atención"
                        },
                        new
                        {
                            Id = 3,
                            Status = true,
                            TableStatusName = "atendida"
                        });
                });

            modelBuilder.Entity("DRRestaurant.Core.Domain.Entities.Dish", b =>
                {
                    b.HasOne("DRRestaurant.Core.Domain.Entities.DishCategory", "Category")
                        .WithMany("Dishes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Dish_Category");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("DRRestaurant.Core.Domain.Entities.DishIngredients", b =>
                {
                    b.HasOne("DRRestaurant.Core.Domain.Entities.Dish", "Dish")
                        .WithMany("DishIngredients")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_DishIngedients_Dish");

                    b.HasOne("DRRestaurant.Core.Domain.Entities.Ingredient", "Ingredient")
                        .WithMany("DishIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_DishIngedients_Ingredient");

                    b.Navigation("Dish");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("DRRestaurant.Core.Domain.Entities.Order", b =>
                {
                    b.HasOne("DRRestaurant.Core.Domain.Entities.Table", "Table")
                        .WithMany()
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Table");
                });

            modelBuilder.Entity("DRRestaurant.Core.Domain.Entities.OrdersDishes", b =>
                {
                    b.HasOne("DRRestaurant.Core.Domain.Entities.Dish", "Dish")
                        .WithMany("Orders")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_OrderDishes_Dish");

                    b.HasOne("DRRestaurant.Core.Domain.Entities.Order", "Order")
                        .WithMany("Dishes")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_OrderDishes_Order");

                    b.Navigation("Dish");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("DRRestaurant.Core.Domain.Entities.Table", b =>
                {
                    b.HasOne("DRRestaurant.Core.Domain.Entities.TableStatus", "TableStatus")
                        .WithMany("Tables")
                        .HasForeignKey("TableStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Order");

                    b.Navigation("TableStatus");
                });

            modelBuilder.Entity("DRRestaurant.Core.Domain.Entities.Dish", b =>
                {
                    b.Navigation("DishIngredients");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("DRRestaurant.Core.Domain.Entities.DishCategory", b =>
                {
                    b.Navigation("Dishes");
                });

            modelBuilder.Entity("DRRestaurant.Core.Domain.Entities.Ingredient", b =>
                {
                    b.Navigation("DishIngredients");
                });

            modelBuilder.Entity("DRRestaurant.Core.Domain.Entities.Order", b =>
                {
                    b.Navigation("Dishes");
                });

            modelBuilder.Entity("DRRestaurant.Core.Domain.Entities.TableStatus", b =>
                {
                    b.Navigation("Tables");
                });
#pragma warning restore 612, 618
        }
    }
}
