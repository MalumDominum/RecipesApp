using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories;
public class CategoryRepository : EFRepository<int, Category, RestaurantContext>
{
    public CategoryRepository(RestaurantContext context) : base(context) { }
}