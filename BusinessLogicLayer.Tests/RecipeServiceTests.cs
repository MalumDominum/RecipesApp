using NUnit.Framework;
using NSubstitute;
using AutoMapper;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using DataAccessLayer;
using DataAccessLayer.Models;

using BusinessLogicLayer.Configuration;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Tests
{
    public class RecipeServiceTests
    {
        private IMapper _mapper;

        [SetUp]
        public void Setup() 
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Test]
        public async void GetRecipeAsync_GetRecipeWithIdEquals3_RecipeRecieved()
        {
            var factory = Substitute.For<IUoWFactory>();
            var uow = Substitute.For<IUnitOfWork>();
            var repo = Substitute.For<IRepository<int, Recipe>>();
            repo.GetByIdAsync(Arg.Any<int>()).Returns(x => GetRecipe((int)x[0]));
            uow.Recipes.Returns(repo);
            factory.CreateUoW().Returns(uow);
            var service = new RecipeService(factory, _mapper);
            var recipeId = 3;

            var result = await service.GetRecipeAsync(recipeId);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.InstanceOf<RecipeDTO>());
                Assert.That(result.Id, Is.EqualTo(recipeId));
            });
        }

        private Recipe GetRecipe(int id)
        {
            return new Recipe { Id = id, Name = "Vegetable stir-fry", CuisineId = 3, CategoryId = 1 };
        }

        private List<RecipeDTO> GetRecipes()
        {
            return new List<RecipeDTO>
            {
                new RecipeDTO { Id = 1, Name = "Vegetable stir-fry", CuisineId = 3, CategoryId = 1 },
                new RecipeDTO { Id = 2, Name = "Spaghetti bolognese", CuisineId = 1, CategoryId = 2 },
                new RecipeDTO { Id = 3, Name = "Beef nachos", CuisineId = 1, CategoryId = 2 },
                new RecipeDTO { Id = 4, Name = "Basic beef burger", CuisineId = 2, CategoryId = 3 }
            };
        }
    }
}