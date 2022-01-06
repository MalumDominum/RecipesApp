using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer;

public class RecipesContext : DbContext
{
    public RecipesContext()
    {
        // For re-create DB (Just run execute on any request, turn off app and comment again)
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = DELLG3MALEKSEEV;" +
                "Database = RecipesDB; Trusted_Connection = True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.Property(e => e.Id)
                  .HasColumnName("user_id");

            entity.Property(e => e.Email)
                  .HasColumnName("email")
                  .HasMaxLength(254)
                  .IsUnicode()
                  .IsRequired();
            entity.HasIndex(e => e.Email)
                  .IsUnique();

            entity.Property(e => e.PasswordHash)
                  .HasColumnName("password_hash");

            entity.Property(e => e.PasswordSalt)
                  .HasColumnName("password_salt");

            entity.Property(e => e.FirstName)
                  .HasColumnName("first_name")
                  .HasMaxLength(50)
                  .IsUnicode()
                  .IsRequired();

            entity.Property(e => e.LastName)
                  .HasColumnName("last_name")
                  .HasMaxLength(50)
                  .IsUnicode()
                  .IsRequired();

            entity.Property(e => e.RegistrationTime)
                  .HasColumnName("registration_time");

            entity.HasMany(u => u.Bookmarks)
                  .WithOne(b => b.User);

            entity.HasMany(u => u.GivenGrades)
                  .WithOne(u => u.User);

            entity.HasMany(u => u.AuthorshipRecipes)
                  .WithOne(ur => ur.Author);
        });

        modelBuilder.Entity<Bookmark>(entity =>
        {
            entity.ToTable("bookmarks");

            entity.HasOne(b => b.User)
                  .WithMany(u => u.Bookmarks)
                  .HasForeignKey(b => b.UserId)
                  .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(b => b.Recipe)
                  .WithMany(r => r.Bookmarks)
                  .HasForeignKey(b => b.RecipeId)
                  .OnDelete(DeleteBehavior.NoAction);

            entity.HasKey(b => new { b.UserId, b.RecipeId });
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.ToTable("grades");

            entity.HasOne(b => b.User)
                .WithMany(u => u.GivenGrades)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(b => b.Recipe)
                .WithMany(r => r.Grades)
                .HasForeignKey(b => b.RecipeId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasKey(b => new { b.UserId, b.RecipeId });
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.ToTable("ingredients");

            entity.Property(e => e.Id)
                  .HasColumnName("ingredient_id");

            entity.Property(e => e.Name)
                  .HasColumnName("name")
                  .HasMaxLength(50)
                  .IsUnicode()
                  .IsRequired();
            entity.HasIndex(e => e.Name)
                  .IsUnique();

            entity.Property(e => e.Image)
                  .HasColumnName("image")
                  .IsRequired(false);

            entity.Property(e => e.Description)
                  .HasColumnName("description")
                  .IsUnicode();

            entity.HasOne(i => i.Group)
                  .WithMany(g => g.Ingredients)
                  .HasForeignKey(i => i.GroupId);

            entity.HasMany(p => p.IngredientRecipePairs)
                  .WithOne(p => p.Ingredient);
        });

        modelBuilder.Entity<IngredientRecipe>(entity =>
        {
            entity.ToTable("ingredient_recipe");

            entity.HasOne(ir => ir.Recipe)
                  .WithMany(r => r.IngredientRecipePairs)
                  .HasForeignKey(ir => ir.RecipeId);

            entity.HasOne(ir => ir.Ingredient)
                  .WithMany(i => i.IngredientRecipePairs)
                  .HasForeignKey(ir => ir.IngredientId);

            entity.HasKey(ir => new { ir.RecipeId, ir.IngredientId });
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.ToTable("recipes");

            entity.Property(e => e.Id)
                  .HasColumnName("recipe_id");

            entity.Property(e => e.Name)
                  .HasColumnName("name")
                  .HasMaxLength(65)
                  .IsUnicode()
                  .IsRequired();

            entity.Property(e => e.Image)
                  .HasColumnName("image")
                  .IsRequired(false);

            entity.Property(e => e.CookingTime)
                  .HasColumnName("cooking_time")
                  .IsRequired();

            entity.Property(e => e.Calories)
                  .HasColumnName("calories");

            entity.Property(e => e.Proteins)
                  .HasColumnName("proteins");

            entity.Property(e => e.Fats)
                  .HasColumnName("fats");

            entity.Property(e => e.Carbs)
                  .HasColumnName("carbs");

            entity.Property(e => e.Description)
                  .HasColumnName("description")
                  .HasMaxLength(1000)
                  .IsUnicode();

            entity.Property(e => e.Steps)
                  .HasColumnName("steps")
                  .IsUnicode();

            entity.HasOne(r => r.Category)
                  .WithMany(c => c.Recipes)
                  .HasForeignKey(r => r.CategoryId);

            entity.HasOne(r => r.Cuisine)
                  .WithMany(c => c.Recipes)
                  .HasForeignKey(r => r.CuisineId);

            entity.HasOne(r => r.Author)
                  .WithMany(c => c.AuthorshipRecipes)
                  .HasForeignKey(r => r.AuthorId);

            entity.HasMany(r => r.Bookmarks)
                  .WithOne(b => b.Recipe);

            entity.HasMany(r => r.IngredientRecipePairs)
                  .WithOne(ir => ir.Recipe);
        });

        modelBuilder.Entity<Cuisine>(entity =>
        {
            entity.ToTable("cuisines");

            entity.Property(e => e.Id)
                  .HasColumnName("cuisine_id");

            entity.Property(e => e.Name)
                  .HasColumnName("name")
                  .HasMaxLength(50)
                  .IsUnicode()
                  .IsRequired();
            entity.HasIndex(e => e.Name)
                  .IsUnique();

            entity.HasMany(c => c.Recipes)
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
                  .IsUnicode()
                  .IsRequired();
            entity.HasIndex(e => e.Name)
                  .IsUnique();

            entity.HasMany(c => c.Recipes)
                  .WithOne(d => d.Category);
        });

        modelBuilder.Entity<IngredientGroup>(entity =>
        {
            entity.ToTable("ingredient_groups");

            entity.Property(e => e.Id)
                  .HasColumnName("group_id");

            entity.Property(e => e.Name)
                  .HasColumnName("name")
                  .HasMaxLength(50)
                  .IsUnicode()
                  .IsRequired();
            entity.HasIndex(e => e.Name)
                  .IsUnique();

            entity.HasMany(ig => ig.Ingredients)
                  .WithOne(i => i.Group);
        });
    }
}