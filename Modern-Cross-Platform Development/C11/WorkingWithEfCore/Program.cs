﻿using static System.Console;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Packt.Shared;

namespace WorkingWithEfCore
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryingCategories();
        }
        static void QueryingCategories()
        {
            using var db = new Northwind();

            WriteLine("Categories and how many products they have:");

            // a query to get all categories and their related products
            IQueryable<Category> cats = db.Categories
            .Include(c => c.Products);

            foreach (Category c in cats)
            {
                WriteLine($"\n{c.CategoryName} has {c.Products.Count} products.");
            }
        }
    }
}
