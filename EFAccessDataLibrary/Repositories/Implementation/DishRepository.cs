using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories;
public class DishRepository : EFRepository<int, Dish, RestaurantContext>
{
    public DishRepository(RestaurantContext context) : base(context) { }
}