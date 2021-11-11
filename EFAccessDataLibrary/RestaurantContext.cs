using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDataAccessLibrary;

public class RestaurantContext : DbContext
{
    public RestaurantContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public RestaurantContext(DbContextOptions options) : base(options) { }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {

    }
}