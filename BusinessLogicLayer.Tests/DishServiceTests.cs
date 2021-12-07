using NUnit.Framework;
using NSubstitute;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using DataAccessLayer;
using DataAccessLayer.Models;

using BusinessLogicLayer.Services;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Tests
{
    public class DishServiceTests
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public async void GetDishAsync_GetDishWithIdEquals3_DishRecieved()
        {
            var factory = Substitute.For<IUoWFactory>();
            var uow = Substitute.For<IUnitOfWork>();
            var repo = Substitute.For<IRepository<int, Dish>>();
            repo.GetByIdAsync(Arg.Any<int>()).Returns(x => GetDish((int)x[0]));
            uow.Dishes.Returns(repo);
            factory.CreateUoW().Returns(uow);
            var service = new DishService(factory);
            var dishId = 3;

            var result = await service.GetDishAsync(dishId);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.InstanceOf<DishDTO>());
                Assert.That(result.Id, Is.EqualTo(dishId));
            });
        }

        private Dish GetDish(int id)
        {
            return new Dish { Id = id, Name = "Vegetable stir-fry", CuisineId = 3, CategoryId = 1 };
        }

        private List<DishDTO> GetDishes()
        {
            return new List<DishDTO>
            {
                new DishDTO { Id = 1, Name = "Vegetable stir-fry", CuisineId = 3, CategoryId = 1 },
                new DishDTO { Id = 2, Name = "Spaghetti bolognese", CuisineId = 1, CategoryId = 2 },
                new DishDTO { Id = 3, Name = "Beef nachos", CuisineId = 1, CategoryId = 2 },
                new DishDTO { Id = 4, Name = "Basic beef burger", CuisineId = 2, CategoryId = 3 }
            };
        }
    }
}