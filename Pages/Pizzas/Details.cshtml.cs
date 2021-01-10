using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaLoco.Data;
using PizzaLoco.Models;

namespace PizzaLoco.Pages.Pizzas
{
    public class DetailsModel : PageModel
    {
        private readonly PizzaLoco.Data.PizzaLocoContext _context;

        public DetailsModel(PizzaLoco.Data.PizzaLocoContext context)
        {
            _context = context;
        }

        public Pizza Pizza { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pizza = await _context.Pizza.FirstOrDefaultAsync(m => m.PizzaId == id);

            if (Pizza == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
