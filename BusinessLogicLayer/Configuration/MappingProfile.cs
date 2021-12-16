using AutoMapper;
using DataAccessLayer.Models;
using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Configuration
{
    public class MappingProfile : Profile
    {
        private void CreateTwoSidedMap<FirstEntity, SecondEntity>()
        {
            CreateMap<FirstEntity, SecondEntity>();
            CreateMap<SecondEntity, FirstEntity>();
        }

        public MappingProfile()
        {
            CreateTwoSidedMap<User, UserDTO>();
            CreateTwoSidedMap<User, UserInfoDTO>();
            CreateTwoSidedMap<Recipe, RecipeDTO>();
            CreateTwoSidedMap<IngredientRecipe, IngredientRecipeDTO>();
            CreateTwoSidedMap<IngredientGroup, IngredientGroupDTO>();
            CreateTwoSidedMap<Ingredient, IngredientDTO>();
            CreateTwoSidedMap<Grade, GradeDTO>();
            CreateTwoSidedMap<Cuisine, CuisineDTO>();
            CreateTwoSidedMap<Category, CategoryDTO>();
            CreateTwoSidedMap<Bookmark, BookmarkDTO>();
        }
    }
}
