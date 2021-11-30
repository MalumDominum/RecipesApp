using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories;
public class OrderDishRepository : EFRepository<int, OrderDish, RestaurantContext>
{
    public OrderDishRepository(RestaurantContext context) : base(context) { }
}