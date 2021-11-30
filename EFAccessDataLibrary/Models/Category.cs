﻿namespace DataAccessLayer.Models;

public class Category
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<Dish> Dishes { get; set; }

    public Category() => Dishes = new();
}