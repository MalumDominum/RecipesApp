using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDataAccessLibrary.Repositories;
public class DishRepository : Repository<Dish>
{
    private RestaurantContext db;

    public DishRepository(RestaurantContext context)
    {
        db = context;
    }

    public IEnumerable<Dish> GetAll()
    {
        return db.Dishes;
    }

    public Dish Get(int id)
    {
        return db.Dishes.Find(id);
    }

    public void Create(Dish dish)
    {
        db.Dishes.Add(dish);
    }

    public void Update(Dish dish)
    {
        db.Entry(dish).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        Dish? dish = db.Dishes.Find(id);

        if (dish != null) db.Dishes.Remove(dish);
    }
}