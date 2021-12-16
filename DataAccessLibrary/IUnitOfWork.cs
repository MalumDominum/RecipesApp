using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<int, User> Users { get; }

        IRepository<int, Bookmark> Bookmarks { get; }

        IRepository<int, Grade> Grades { get; }

        IRepository<int, Ingredient> Ingredients { get; }

        IRepository<int, IngredientGroup> IngredientGroups { get; }

        IRepository<int, IngredientRecipe> IngredientRecipe { get; }

        IRepository<int, Recipe> Recipes { get; }

        IRepository<int, Category> Categories { get; }

        IRepository<int, Cuisine> Cuisines { get; }

        Task SaveAsync();
    }
}
