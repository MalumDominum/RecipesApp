using DataAccessLayer.Repositories;

namespace DataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        CategoryRepository Categories { get; }

        CuisineRepository Cuisines { get; }

        DishPortionRepository DishPortions { get; }

        DishRepository Dishes { get; }

        IngredientDishRepository IngredientDish { get; }

        IngredientRepository Ingredients { get; }

        OrderDishRepository OrderDish { get; }

        OrderRepository Orders { get; }

        Task SaveAsync();
    }
}
