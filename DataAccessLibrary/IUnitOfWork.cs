using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<int, Category> Categories { get; }

        IRepository<int, Cuisine> Cuisines { get; }

        IRepository<int, DishPortion> DishPortions { get; }

        IRepository<int, Dish> Dishes { get; }

        IRepository<int, IngredientDish> IngredientDish { get; }

        IRepository<int, Ingredient> Ingredients { get; }

        IRepository<int, OrderDish> OrderDish { get; }

        IRepository<int, Order> Orders { get; }

        IRepository<int, User> Users { get; }

        Task SaveAsync();
    }
}
