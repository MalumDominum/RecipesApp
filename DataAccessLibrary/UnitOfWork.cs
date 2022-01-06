using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RecipesContext _db;
        public UnitOfWork() => _db = new();

        private IRepository<int, User> _userRepository;
        private IRepository<(int, int), Bookmark> _bookmarkRepository;
        private IRepository<(int, int), Grade> _gradeRepository;
        private IRepository<int, Ingredient> _ingredientRepository;
        private IRepository<int, IngredientGroup> _ingredientGroupRepository;
        private IRepository<(int, int), IngredientRecipe> _ingredientRecipeRepository;
        private IRepository<int, Recipe> _recipeRepository;
        private IRepository<int, Category> _categoryRepository;
        private IRepository<int, Cuisine> _cuisineRepository;

        public IRepository<int, User> Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new EFRepository<int, User, RecipesContext>(_db);
                return _userRepository;
            }
        }

        public IRepository<(int, int), Bookmark> Bookmarks
        {
            get
            {
                if (_bookmarkRepository == null)
                    _bookmarkRepository = new EFRepository<(int, int), Bookmark, RecipesContext>(_db);
                return _bookmarkRepository;
            }
        }

        public IRepository<(int, int), Grade> Grades
        {
            get
            {
                if (_gradeRepository == null)
                    _gradeRepository = new EFRepository<(int, int), Grade, RecipesContext>(_db);
                return _gradeRepository;
            }
        }

        public IRepository<int, Ingredient> Ingredients
        {
            get
            {
                if (_ingredientRepository == null)
                    _ingredientRepository = new EFRepository<int, Ingredient, RecipesContext>(_db);
                return _ingredientRepository;
            }
        }

        public IRepository<int, IngredientGroup> IngredientGroups
        {
            get
            {
                if (_ingredientGroupRepository == null)
                    _ingredientGroupRepository = new EFRepository<int, IngredientGroup, RecipesContext>(_db);
                return _ingredientGroupRepository;
            }
        }

        public IRepository<(int, int), IngredientRecipe> IngredientRecipe
        {
            get
            {
                if (_ingredientRecipeRepository == null)
                    _ingredientRecipeRepository = new EFRepository<(int, int), IngredientRecipe, RecipesContext>(_db);
                return _ingredientRecipeRepository;
            }
        }

        public IRepository<int, Recipe> Recipes
        {
            get
            {
                if (_recipeRepository == null)
                    _recipeRepository = new EFRepository<int, Recipe, RecipesContext>(_db);
                return _recipeRepository;
            }
        }

        public IRepository<int, Category> Categories
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new EFRepository<int, Category, RecipesContext>(_db);
                return _categoryRepository;
            }
        }

        public IRepository<int, Cuisine> Cuisines
        {
            get
            {
                if (_cuisineRepository == null)
                    _cuisineRepository = new EFRepository<int, Cuisine, RecipesContext>(_db);
                return _cuisineRepository;
            }
        }

        public async Task SaveAsync() => await _db.SaveChangesAsync();

        private bool _disposed;

        public virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing) _db.Dispose();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
