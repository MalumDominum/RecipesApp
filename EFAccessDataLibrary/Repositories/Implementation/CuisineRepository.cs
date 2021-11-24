using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories;
public class CuisineRepository : EFRepository<int, Cuisine, RestaurantContext>
{
    public CuisineRepository(RestaurantContext context) : base(context) { }
}