using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDataAccessLibrary.Repositories;
public class OrderRepository : Repository<Order>
{
    private RestaurantContext db;

    public OrderRepository(RestaurantContext context)
    {
        db = context;
    }

    public IEnumerable<Order> GetAll()
    {
        return db.Orders;
    }

    public Order Get(int id)
    {
        return db.Orders.Find(id);
    }

    public void Create(Order order)
    {
        db.Orders.Add(order);
    }

    public void Update(Order order)
    {
        db.Entry(order).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        Order? book = db.Orders.Find(id);

        if (book != null) db.Orders.Remove(book);
    }
}
