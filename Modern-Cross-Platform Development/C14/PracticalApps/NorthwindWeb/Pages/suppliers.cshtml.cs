using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Packt.Shared;
using System;

namespace NorthwindWeb.Pages
{
    public class SuppliersModel : PageModel
    {
        [BindProperty]
        public Supplier Supplier { get; set; }
        public IEnumerable<string> Suppliers { get; set; }
        private Northwind db;

        public SuppliersModel(Northwind injectedContext)
        {
            db = injectedContext;
        }
        public void OnGet()
        {
            ViewData["Title"] = "Northwind Web Site - Suppliers";
            Suppliers  =  Array.Empty<string>();// db.Suppliers.AsQueryable().Select(s => s.CompanyName);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(Supplier);
                db.SaveChanges();
                return RedirectToPage("/suppliers");
            }
            return Page();
        }
    }
}