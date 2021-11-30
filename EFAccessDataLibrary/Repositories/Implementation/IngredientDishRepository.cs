using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories;
public class IngredientDishRepository : EFRepository<int, IngredientDish, RestaurantContext>
{
    public IngredientDishRepository(RestaurantContext context) : base(context) { }
}