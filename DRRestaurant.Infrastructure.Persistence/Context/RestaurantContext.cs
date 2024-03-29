

using DRRestaurant.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DRRestaurant.Infrastructure.Identity.Context
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) { }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DishCategory> DishCategories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set;}
        public DbSet<OrdersDishes> OrdersDishes { get;set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<TableStatus> TableStatus { get; set; }
        public DbSet<DishIngredients> DishIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Tables
            modelBuilder.Entity<Dish>().ToTable("Dishes");
            modelBuilder.Entity<Ingredient>().ToTable("Ingredients");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<DishCategory>().ToTable("DishCategories");
            modelBuilder.Entity<DishIngredients>().ToTable("DishIngredients");
            modelBuilder.Entity<OrdersDishes>().ToTable("OrderDishes");
            modelBuilder.Entity<Table>().ToTable("Tables");
            modelBuilder.Entity<TableStatus>().ToTable("TableStatus");
            #endregion

            #region Keys
            modelBuilder.Entity<Dish>().HasKey(x => x.Id);
            modelBuilder.Entity<Ingredient>().HasKey(x => x.Id);
            modelBuilder.Entity<Order>().HasKey(x => x.Id);
            modelBuilder.Entity<DishCategory>().HasKey(x => x.Id);
            modelBuilder.Entity<DishIngredients>().HasKey(x => x.Id);
            modelBuilder.Entity<OrdersDishes>().HasKey(x => x.Id);
            modelBuilder.Entity<Table>().HasKey(x => x.Id);
            modelBuilder.Entity<TableStatus>().HasKey(x => x.Id);
            #endregion

            #region Relantionships

            #region Dish
            modelBuilder.Entity<Dish>()
               .HasOne(d => d.Category)
               .WithMany(c => c.Dishes)
               .HasForeignKey(d => d.CategoryId)
               .HasConstraintName("FK_Dish_Category")
               .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region DishIngredient
            modelBuilder.Entity<DishIngredients>()
                .HasOne(di => di.Dish)
                .WithMany(d => d.DishIngredients)
                .HasForeignKey(di => di.DishId)
                .HasConstraintName("FK_DishIngedients_Dish")
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DishIngredients>()
                .HasOne(di => di.Ingredient)
                .WithMany(d => d.DishIngredients)
                .HasForeignKey(di => di.IngredientId)
                .HasConstraintName("FK_DishIngedients_Ingredient")
               .OnDelete(DeleteBehavior.Restrict); ;

            #endregion

            #region OrderDishes
            modelBuilder.Entity<OrdersDishes>()
                .HasOne(od =>od.Dish)
                .WithMany(d => d.Orders)
                .HasForeignKey(od => od.DishId)
                .HasConstraintName("FK_OrderDishes_Dish")
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrdersDishes>()
                .HasOne(od => od.Order)
                .WithMany(d => d.Dishes)
                .HasForeignKey(od => od.OrderId)
                .HasConstraintName("FK_OrderDishes_Order")
               .OnDelete(DeleteBehavior.Restrict); ;

            #endregion

            #region Table
            modelBuilder.Entity<Table>()
                .HasOne(t => t.TableStatus)
                .WithMany(ts => ts.Tables)
                .HasForeignKey(t => t.TableStatusId)
                .HasConstraintName("FK_Order")
                .OnDelete(DeleteBehavior.Restrict);
            #endregion



            #endregion

            #region Properties Configuration

            #region Order

            modelBuilder.Entity<Order>().
                Property(x => x.SubTotal)
                .IsRequired();
            #endregion


            #region Dish
            modelBuilder.Entity<Dish>().
               Property(x => x.Name)
               .IsRequired();

            modelBuilder.Entity<Dish>().
                  Property(x => x.Price)
                  .IsRequired();

            modelBuilder.Entity<Dish>().
                Property(x => x.QuantityOfPeople)
                .IsRequired();
            #endregion


            #region Ingredient
            modelBuilder.Entity<Ingredient>().
                Property(x => x.Name)
                .IsRequired();
            #endregion


            #region Table
            modelBuilder.Entity<Table>().
              Property(x => x.QuantityOfPersonOntheTable)
              .IsRequired();

            modelBuilder.Entity<Table>().
               Property(x => x.Description)
               .IsRequired();
            #endregion


            #region DishCategory
            modelBuilder.Entity<DishCategory>().
                 Property(x => x.CategoryName)
                 .IsRequired();

            #region Data Insertion of Category

            modelBuilder.Entity<DishCategory>().HasData(
               new DishCategory
               {
                   Id = 1,
                   CategoryName = "Entrada",
                   Status = true
               },
                 new DishCategory
                 {
                      Id = 2,
                     CategoryName = "Plato fuerte",
                     Status = true
                 },
                   new DishCategory
                   {
                       Id = 3,
                       CategoryName = "Postre",
                       Status = true
                   },
                     new DishCategory
                     {
                         Id = 4,
                         CategoryName = "Bebida",
                         Status = true
                     }

                );
            #endregion

            #endregion


            #region DishIngredients 

            modelBuilder.Entity<DishIngredients>().
               Property(x => x.IngredientId)
               .IsRequired();

            modelBuilder.Entity<DishIngredients>().
             Property(x => x.DishId)
             .IsRequired();
            #endregion


            #region OrderDishes
            modelBuilder.Entity<OrdersDishes>().
             Property(x => x.OrderId)
             .IsRequired();

            modelBuilder.Entity<OrdersDishes>().
            Property(x => x.DishId)
            .IsRequired();
            #endregion

            #region TableStatus
            modelBuilder.Entity<TableStatus>().
                 Property(x => x.TableStatusName)
                 .IsRequired();

            #region Data insertion of TableStatus

            modelBuilder.Entity<TableStatus>()
                .HasData(
                new TableStatus
                {
                    Id = 1,
                    TableStatusName = "Disponible",
                },
                 new TableStatus
                 {
                     Id = 2,
                     TableStatusName = "en proceso de atención",
                 },
                  new TableStatus
                  {
                      Id = 3,
                      TableStatusName = "atendida",
                  }
                );

            #endregion
            #endregion

            #endregion

        }
    }
}
