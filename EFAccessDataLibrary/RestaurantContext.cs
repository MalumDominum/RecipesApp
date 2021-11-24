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
                  .IsRequired();
            entity.HasIndex(e => e.Name)
                  .IsUnique();

            entity.Property(e => e.Description)
                  .HasColumnName("description");

            entity.HasMany(p => p.Dishes)
                  .WithMany(p => p.Ingredients)
                  .UsingEntity(j => j.ToTable("igredient_dish"));
        });

        modelBuilder.Entity<Dish>(entity =>
        {
            entity.ToTable("dishes");

            entity.Property(e => e.Id)
                  .HasColumnName("dish_id");

            entity.Property(e => e.Name)
                  .HasColumnName("name")
                  .HasMaxLength(100)
                  .IsRequired();

            entity.Property(e => e.Description)
                  .HasColumnName("description");

            entity.HasMany(d => d.Ingredients)
                  .WithMany(i => i.Dishes)
                  .UsingEntity(j => j.ToTable("igredient_dish"));

            entity.HasOne(d => d.Category)
                  .WithMany();

            entity.HasOne(d => d.Cuisine)
                  .WithMany();

            entity.HasMany(d => d.DishPortions)
                  .WithOne();
        });

        modelBuilder.Entity<DishPortion>(entity =>
        {
            entity.ToTable("dish_portions");

            entity.Property(e => e.Id)
                  .HasColumnName("dish_portion_id");

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
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("orders");

            entity.Property(e => e.Id)
                  .HasColumnName("order_id");

            entity.Property(e => e.CustomerName)
                  .HasColumnName("customer_name")
                  .HasMaxLength(150)
                  .IsRequired();

            entity.Property(e => e.RequestTime)
                  .HasColumnName("request_time")
                  .HasDefaultValue(DateTime.Now);

            entity.Property(e => e.ServingTime)
                  .HasColumnName("serving_time");

            entity.HasMany(o => o.Dishes)
                  .WithMany(d => d.Orders)
                  .UsingEntity(j => j.ToTable("order_dish"));
        });

        modelBuilder.Entity<Cuisine>(entity =>
        {
            entity.ToTable("cuisines");

            entity.Property(e => e.Id)
                  .HasColumnName("cuisine_id");

            entity.Property(e => e.Name)
                  .HasColumnName("name")
                  .HasMaxLength(50)
                  .IsRequired();
            entity.HasIndex(e => e.Name)
                  .IsUnique();

            entity.Property(e => e.Description)
                  .HasColumnName("description");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("categories");

            entity.Property(e => e.Id)
                  .HasColumnName("category_id");

            entity.Property(e => e.Name)
                  .HasColumnName("name")
                  .HasMaxLength(50)
                  .IsRequired();
            entity.HasIndex(e => e.Name)
                  .IsUnique();
        });
    }

    void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {

    }
}