using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer;

public class RestaurantContext : DbContext
{
    public RestaurantContext() : base() { }

    public RestaurantContext(DbContextOptions options) : base(options)
    {
        // For re-create DB (Just run execute, turn off app and comment again)
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Dish> Dishes { get; set; }

    public virtual DbSet<DishPortion> DishPortions { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Cuisine> Cuisines { get; set; }

    public virtual DbSet<IngredientDish> IngredientDish { get; set; }

    public virtual DbSet<OrderDish> OrderDish { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = DELLG3MALEKSEEV; Database = RestaurantDB; Trusted_Connection = True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.ToTable("ingredients");

            entity.Property(e => e.Id)
                  .HasColumnName("ingredient_id");

            entity.Property(e => e.Name)
                  .HasColumnName("name")
                  .HasMaxLength(50)
                  .IsUnicode(true)
                  .IsRequired();
            entity.HasIndex(e => e.Name)
                  .IsUnique();

            entity.Property(e => e.Description)
                  .HasColumnName("description")
                  .IsUnicode(true);

            entity.HasMany(p => p.IngredientDishPairs)
                  .WithOne(p => p.Ingredient);
        });

        modelBuilder.Entity<IngredientDish>(entity =>
        {
            entity.ToTable("ingredient_dish");

            entity.HasOne(id => id.Dish)
                  .WithMany(d => d.IngredientDishPairs)
                  .HasForeignKey(id => id.DishId);

            entity.HasOne(id => id.Ingredient)
                  .WithMany(i => i.IngredientDishPairs)
                  .HasForeignKey(id => id.IngredientId);

            entity.HasKey(id => new { id.DishId, id.IngredientId });
        });

        modelBuilder.Entity<Dish>(entity =>
        {
            entity.ToTable("dishes");

            entity.Property(e => e.Id)
                  .HasColumnName("dish_id");

            entity.Property(e => e.Name)
                  .HasColumnName("name")
                  .HasMaxLength(100)
                  .IsUnicode(true)
                  .IsRequired();

            entity.Property(e => e.Description)
                  .HasColumnName("description")
                  .IsUnicode(true);

            entity.HasMany(d => d.IngredientDishPairs)
                  .WithOne(id => id.Dish);

            entity.HasMany(d => d.OrderDishPairs)
                  .WithOne(od => od.Dish);

            entity.HasOne(d => d.Category)
                  .WithMany(c => c.Dishes)
                  .HasForeignKey(d => d.CategoryId);

            entity.HasOne(d => d.Cuisine)
                  .WithMany(c => c.Dishes)
                  .HasForeignKey(d => d.CuisineId);

            entity.HasMany(d => d.DishPortions)
                  .WithOne(dp => dp.Dish);
        });

        modelBuilder.Entity<OrderDish>(entity =>
        {
            entity.ToTable("order_dish");

            entity.HasOne(od => od.Order)
                  .WithMany(o => o.OrderDishPairs)
                  .HasForeignKey(od => od.OrderId);

            entity.HasOne(od => od.Dish)
                  .WithMany(d => d.OrderDishPairs)
                  .HasForeignKey(od => od.DishId);

            entity.HasKey(id => new { id.DishId, id.OrderId });
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("orders");

            entity.Property(e => e.Id)
                  .HasColumnName("order_id");

            entity.Property(e => e.CustomerName)
                  .HasColumnName("customer_name")
                  .HasMaxLength(150)
                  .IsUnicode(true)
                  .IsRequired();

            entity.Property(e => e.RequestTime)
                  .HasColumnName("request_time")
                  .HasDefaultValue(DateTime.Now);

            entity.Property(e => e.ServingTime)
                  .HasColumnName("serving_time");

            entity.HasMany(o => o.OrderDishPairs)
                  .WithOne(d => d.Order);
        });

        modelBuilder.Entity<DishPortion>(entity =>
        {
            entity.ToTable("dish_portions");

            entity.Property(e => e.Id)
                  .HasColumnName("dish_portion_id");

            entity.Property(e => e.Cost)
                  .HasColumnName("cost")
                  .IsRequired();

            entity.Property(e => e.Weight)
                  .HasColumnName("weight")
                  .IsRequired();

            entity.Property(e => e.Calories)
                  .HasColumnName("calories");

            entity.Property(e => e.Proteins)
                  .HasColumnName("proteins");

            entity.Property(e => e.Fats)
                  .HasColumnName("fats");

            entity.Property(e => e.Carbs)
                  .HasColumnName("carbs");

            entity.HasOne(dp => dp.Dish)
                  .WithMany(d => d.DishPortions)
                  .HasForeignKey(dp => dp.DishId);
        });

        modelBuilder.Entity<Cuisine>(entity =>
        {
            entity.ToTable("cuisines");

            entity.Property(e => e.Id)
                  .HasColumnName("cuisine_id");

            entity.Property(e => e.Name)
                  .HasColumnName("name")
                  .HasMaxLength(50)
                  .IsUnicode(true)
                  .IsRequired();
            entity.HasIndex(e => e.Name)
                  .IsUnique();

            entity.Property(e => e.Description)
                  .HasColumnName("description")
                  .IsUnicode(true);

            entity.HasMany(c => c.Dishes)
                  .WithOne(d => d.Cuisine);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("categories");

            entity.Property(e => e.Id)
                  .HasColumnName("category_id");

            entity.Property(e => e.Name)
                  .HasColumnName("name")
                  .HasMaxLength(50)
                  .IsUnicode(true)
                  .IsRequired();
            entity.HasIndex(e => e.Name)
                  .IsUnique();

            entity.HasMany(c => c.Dishes)
                  .WithOne(d => d.Category);
        });
    }

    private static void OnModelCreatingPartial(ModelBuilder modelBuilder) { }
}