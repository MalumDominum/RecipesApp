using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RestaurantContext db;
        public UnitOfWork() => db = new();

        private IRepository<int, Category> categoryRepository;
        private IRepository<int, Cuisine> cuisineRepository;
        private IRepository<int, DishPortion> dishPortionRepository;
        private IRepository<int, Dish> dishRepository;
        private IRepository<int, IngredientDish> ingredientDishRepository;
        private IRepository<int, Ingredient> ingredientRepository;
        private IRepository<int, OrderDish> orderDishRepository;
        private IRepository<int, Order> orderRepository;

        public IRepository<int, Category> Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new EFRepository<int, Category, RestaurantContext>(db);
                return categoryRepository;
            }
        }

        public IRepository<int, Cuisine> Cuisines
        {
            get
            {
                if (cuisineRepository == null)
                    cuisineRepository = new EFRepository<int, Cuisine, RestaurantContext>(db);
                return cuisineRepository;
            }
        }

        public IRepository<int, DishPortion> DishPortions
        {
            get
            {
                if (dishPortionRepository == null)
                    dishPortionRepository = new EFRepository<int, DishPortion, RestaurantContext>(db);
                return dishPortionRepository;
            }
        }

        public IRepository<int, Dish> Dishes
        {
            get
            {
                if (dishRepository == null)
                    dishRepository = new EFRepository<int, Dish, RestaurantContext>(db);
                return dishRepository;
            }
        }

        public IRepository<int, IngredientDish> IngredientDish
        {
            get
            {
                if (ingredientDishRepository == null)
                    ingredientDishRepository = new EFRepository<int, IngredientDish, RestaurantContext>(db);
                return ingredientDishRepository;
            }
        }

        public IRepository<int, Ingredient> Ingredients
        {
            get
            {
                if (ingredientRepository == null)
                    ingredientRepository = new EFRepository<int, Ingredient, RestaurantContext>(db);
                return ingredientRepository;
            }
        }

        public IRepository<int, OrderDish> OrderDish
        {
            get
            {
                if (orderDishRepository == null)
                    orderDishRepository = new EFRepository<int, OrderDish, RestaurantContext>(db);
                return orderDishRepository;
            }
        }

        public IRepository<int, Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new EFRepository<int, Order, RestaurantContext>(db);
                return orderRepository;
            }
        }

        public async Task SaveAsync() => await db.SaveChangesAsync();

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    db.Dispose();

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
