using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories;
public class OrderRepository : EFRepository<int, Order, RestaurantContext>
{
    public OrderRepository(RestaurantContext context) : base(context) { }
}