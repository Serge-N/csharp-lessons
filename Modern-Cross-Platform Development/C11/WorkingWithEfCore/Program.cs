using static System.Console;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq;
using Packt.Shared;
using System;

namespace WorkingWithEfCore
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryingCategories();
            //FilteredIncludes();
            // QueryingProducts();
            //QueryingWithLike();
        }

        static void QueryingCategories()
        {
            using var db = new Northwind();

            var loggerFactory = db.GetService<ILoggerFactory>();
            loggerFactory.AddProvider(new ConsoleLoggerProvider());

            WriteLine("Categories and how many products they have:");

            // a query to get all categories and their related products
            IQueryable<Category> cats;//= db.Categories.Include(c => c.Products);

            db.ChangeTracker.LazyLoadingEnabled = false;

            Write("Enable eager loading? (Y/N): ");
            bool eagerloading = (ReadKey().Key == ConsoleKey.Y);
            bool explicitloading = false;
            
            WriteLine();

            if (eagerloading)
            {
                cats = db.Categories.Include(c => c.Products);
            }
            else
            {
                cats = db.Categories;
                Write("Enable explicit loading? (Y/N): ");
                explicitloading = (ReadKey().Key == ConsoleKey.Y);
                WriteLine();
            }

            foreach (Category c in cats)
            {
                WriteLine($"\n{c.CategoryName} has {c.Products.Count} products.");
            }
        }

        static void FilteredIncludes()
        {
            using (var db = new Northwind())
            {
                Write("Enter a minimum for units in stock: ");

                string unitsInStock = ReadLine();
                int stock = int.Parse(unitsInStock);

                IQueryable<Category> cats = db.Categories
                .Include(c => c.Products.Where(p => p.Stock >= stock));

                WriteLine($"ToQueryString: {cats.ToQueryString()}");

                foreach (Category c in cats)
                {
                    WriteLine($"{c.CategoryName} has {c.Products.Count} products with a minimum of { stock} units in stock.");

                    foreach (Product p in c.Products)
                    {
                        WriteLine($"\n {p.ProductName} has {p.Stock} units in stock.");
                    }
                }
            }
        }

        static void QueryingProducts()
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

                WriteLine("Products that cost more than a price, highest at top.");

                string input;
                decimal price;

                do
                {
                    Write("Enter a product price: ");
                    input = ReadLine();
                }
                while (!decimal.TryParse(input, out price));

                IQueryable<Product> prods = db.Products
                .TagWith("Products filtered by price and sorted.")
                .Where(product => product.Cost > price).OrderByDescending(product => product.Cost);

                foreach (Product item in prods)
                {
                    WriteLine(
                    "\n{0}: {1} costs {2:$#,##0.00} and has {3} in stock.",
                    item.ProductID, item.ProductName, item.Cost, item.Stock);
                }
            }
        }
        static void QueryingWithLike()
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

                Write("Enter part of a product name: ");
                string input = ReadLine();

                IQueryable<Product> prods = db.Products.Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));

                foreach (Product item in prods)
                {
                    WriteLine("{0} has {1} units in stock. Discontinued? {2}", item.ProductName, item.Stock, item.Discontinued);
                }
            }

        }
    }
}