using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<int, User> Users { get; }

        IRepository<(int, int), Bookmark> Bookmarks { get; }

        IRepository<(int, int), Grade> Grades { get; }

        IRepository<int, Ingredient> Ingredients { get; }

        IRepository<int, IngredientGroup> IngredientGroups { get; }

        IRepository<(int, int), IngredientRecipe> IngredientRecipe { get; }

        IRepository<int, Recipe> Recipes { get; }

        IRepository<int, Category> Categories { get; }

        IRepository<int, Cuisine> Cuisines { get; }

        Task SaveAsync();
    }
}
