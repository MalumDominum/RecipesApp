using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;

namespace DataAccessLayer
{
    public class UnitOfWork : IDisposable
    {
        private readonly RestaurantContext db;
        public UnitOfWork() => db = new();

        private CategoryRepository categoryRepository;
        private CuisineRepository cuisineRepository;
        private DishPortionRepository dishPortionRepository;
        private DishRepository dishRepository;
        private IngredientDishRepository ingredientDishRepository;
        private IngredientRepository ingredientRepository;
        private OrderDishRepository orderDishRepository;
        private OrderRepository orderRepository;

        public CategoryRepository Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(db);
                return categoryRepository;
            }
        }

        public CuisineRepository Cuisines
        {
            get
            {
                if (cuisineRepository == null)
                    cuisineRepository = new CuisineRepository(db);
                return cuisineRepository;
            }
        }

        public DishPortionRepository DishPortions
        {
            get
            {
                if (dishPortionRepository == null)
                    dishPortionRepository = new DishPortionRepository(db);
                return dishPortionRepository;
            }
        }

        public DishRepository Dishes
        {
            get
            {
                if (dishRepository == null)
                    dishRepository = new DishRepository(db);
                return dishRepository;
            }
        }

        public IngredientDishRepository IngredientDish
        {
            get
            {
                if (ingredientDishRepository == null)
                    ingredientDishRepository = new IngredientDishRepository(db);
                return ingredientDishRepository;
            }
        }

        public IngredientRepository Ingredients
        {
            get
            {
                if (ingredientRepository == null)
                    ingredientRepository = new IngredientRepository(db);
                return ingredientRepository;
            }
        }

        public OrderDishRepository OrderDish
        {
            get
            {
                if (orderDishRepository == null)
                    orderDishRepository = new OrderDishRepository(db);
                return orderDishRepository;
            }
        }

        public OrderRepository Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
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
