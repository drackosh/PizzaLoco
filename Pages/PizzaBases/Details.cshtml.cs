using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaLoco.Data;
using PizzaLoco.Models;

namespace PizzaLoco.Pages.PizzaBases
{
    public class DetailsModel : PageModel
    {
        private readonly PizzaLoco.Data.PizzaLocoContext _context;

        public DetailsModel(PizzaLoco.Data.PizzaLocoContext context)
        {
            _context = context;
        }

        public PizzaBase PizzaBase { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PizzaBase = await _context.PizzaBase.FirstOrDefaultAsync(m => m.PizzaBaseId == id);

            if (PizzaBase == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
