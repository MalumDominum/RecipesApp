using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDataAccessLibrary.Repositories;
using EFDataAccessLibrary.Models;

namespace EFDataAccessLibrary
{
    public class UnitOfWork : IDisposable
    {
        private RestaurantContext db = new RestaurantContext();

        private CategoryRepository categoryRepository;
        private CuisineRepository cuisineRepository;
        private DishPortionRepository dishPortionRepository;
        private DishRepository dishRepository;
        private IngredientRepository ingredientRepository;
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

        public IngredientRepository Ingredients
        {
            get
            {
                if (ingredientRepository == null)
                    ingredientRepository = new IngredientRepository(db);
                return ingredientRepository;
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

        public void Save()
        {
            db.SaveChanges();
        }

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
