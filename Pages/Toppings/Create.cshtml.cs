﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaLoco.Data;
using PizzaLoco.Models;

namespace PizzaLoco.Pages.Toppings
{
    public class CreateModel : PageModel
    {
        private readonly PizzaLoco.Data.PizzaLocoContext _context;

        public CreateModel(PizzaLoco.Data.PizzaLocoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Topping Topping { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Topping.Add(Topping);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
