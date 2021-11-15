using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDataAccessLibrary.Repositories;
public class CuisineRepository : Repository<Cuisine>
{
    private RestaurantContext db;

    public CuisineRepository(RestaurantContext context) { db = context; }

    public IEnumerable<Cuisine> GetAll() => db.Cuisines;

    public Cuisine Get(int id) => db.Cuisines.Find(id);

    public void Create(Cuisine cuisine) => db.Cuisines.Add(cuisine);

    public void Update(Cuisine cuisine) => db.Entry(cuisine).State = EntityState.Modified;
    
    public void Delete(int id)
    {
        Cuisine? cuisine = db.Cuisines.Find(id);

        if (cuisine != null) db.Cuisines.Remove(cuisine);
    }
}
