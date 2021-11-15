using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDataAccessLibrary.Repositories;
public class DishPortionRepository : Repository<DishPortion>
{
    private RestaurantContext db;

    public DishPortionRepository(RestaurantContext context) { db = context; }

    public IEnumerable<DishPortion> GetAll() => db.DishPortions;
    
    public DishPortion Get(int id) => db.DishPortions.Find(id);
    
    public void Create(DishPortion dishPortion) => db.DishPortions.Add(dishPortion);
    
    public void Update(DishPortion dishPortion) => db.Entry(dishPortion).State = EntityState.Modified;
    
    public void Delete(int id)
    {
        DishPortion? dishPortion = db.DishPortions.Find(id);

        if (dishPortion != null) db.DishPortions.Remove(dishPortion);
    }
}