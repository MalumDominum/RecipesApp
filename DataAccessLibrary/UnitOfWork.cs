using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RecipesContext db;
        public UnitOfWork() => db = new();

        private IRepository<int, User> userRepository;
        private IRepository<int, Bookmark> bookmarkRepository;
        private IRepository<int, Grade> gradeRepository;
        private IRepository<int, Ingredient> ingredientRepository;
        private IRepository<int, IngredientGroup> ingredientGroupRepository;
        private IRepository<int, IngredientRecipe> ingredientRecipeRepository;
        private IRepository<int, Recipe> recipeRepository;
        private IRepository<int, Category> categoryRepository;
        private IRepository<int, Cuisine> cuisineRepository;

        public IRepository<int, User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new EFRepository<int, User, RecipesContext>(db);
                return userRepository;
            }
        }

        public IRepository<int, Bookmark> Bookmarks
        {
            get
            {
                if (bookmarkRepository == null)
                    bookmarkRepository = new EFRepository<int, Bookmark, RecipesContext>(db);
                return bookmarkRepository;
            }
        }

        public IRepository<int, Grade> Grades
        {
            get
            {
                if (gradeRepository == null)
                    gradeRepository = new EFRepository<int, Grade, RecipesContext>(db);
                return gradeRepository;
            }
        }

        public IRepository<int, Ingredient> Ingredients
        {
            get
            {
                if (ingredientRepository == null)
                    ingredientRepository = new EFRepository<int, Ingredient, RecipesContext>(db);
                return ingredientRepository;
            }
        }

        public IRepository<int, IngredientGroup> IngredientGroups
        {
            get
            {
                if (ingredientGroupRepository == null)
                    ingredientGroupRepository = new EFRepository<int, IngredientGroup, RecipesContext>(db);
                return ingredientGroupRepository;
            }
        }

        public IRepository<int, IngredientRecipe> IngredientRecipe
        {
            get
            {
                if (ingredientRecipeRepository == null)
                    ingredientRecipeRepository = new EFRepository<int, IngredientRecipe, RecipesContext>(db);
                return ingredientRecipeRepository;
            }
        }

        public IRepository<int, Recipe> Recipes
        {
            get
            {
                if (recipeRepository == null)
                    recipeRepository = new EFRepository<int, Recipe, RecipesContext>(db);
                return recipeRepository;
            }
        }

        public IRepository<int, Category> Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new EFRepository<int, Category, RecipesContext>(db);
                return categoryRepository;
            }
        }

        public IRepository<int, Cuisine> Cuisines
        {
            get
            {
                if (cuisineRepository == null)
                    cuisineRepository = new EFRepository<int, Cuisine, RecipesContext>(db);
                return cuisineRepository;
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
