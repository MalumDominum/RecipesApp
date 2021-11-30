using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories;
public class DishRepository : EFRepository<int, Dish, RestaurantContext>
{
    public DishRepository(RestaurantContext context) : base(context) { }

    public virtual async Task<List<Dish>> GetAllByCategoryAsync(int categoryId)
    {
        return await Context.Set<Dish>()
                            .Where(x => x.Category.Id == categoryId)
                            .ToListAsync();
    }

    public virtual async Task<List<Dish>> GetAllByCuisineAsync(int cuisineId)
    {
        return await Context.Set<Dish>()
                            .Where(x => x.Cuisine.Id == cuisineId)
                            .ToListAsync();
    }
}