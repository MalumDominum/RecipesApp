using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories;
public class DishPortionRepository : EFRepository<int, DishPortion, RestaurantContext>
{
    public DishPortionRepository(RestaurantContext context) : base(context) { }
}