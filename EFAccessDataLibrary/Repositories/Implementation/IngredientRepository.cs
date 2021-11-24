using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories;
public class IngredientRepository : EFRepository<int, Ingredient, RestaurantContext>
{
    public IngredientRepository(RestaurantContext context) : base(context) { }
}