using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDataAccessLibrary.Repositories;
public class IngredientRepository : Repository<Ingredient>
{
    private RestaurantContext db;

    public IngredientRepository(RestaurantContext context)
    {
        db = context;
    }

    public IEnumerable<Ingredient> GetAll()
    {
        return db.Ingredients;
    }

    public Ingredient Get(int id)
    {
        return db.Ingredients.Find(id);
    }

    public void Create(Ingredient ingredient)
    {
        db.Ingredients.Add(ingredient);
    }

    public void Update(Ingredient ingredient)
    {
        db.Entry(ingredient).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        Ingredient? ingredient = db.Ingredients.Find(id);

        if (ingredient != null) db.Ingredients.Remove(ingredient);
    }
}