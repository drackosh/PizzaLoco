using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaLoco.Data;
using PizzaLoco.Models;

namespace PizzaLoco.Pages.PizzaOrders
{
    public class DetailsModel : PageModel
    {
        private readonly PizzaLoco.Data.PizzaLocoContext _context;

        public DetailsModel(PizzaLoco.Data.PizzaLocoContext context)
        {
            _context = context;
        }

        public PizzaOrder PizzaOrder { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PizzaOrder = await _context.PizzaOrder
                .Include(p => p.Client)
                .Include(p => p.Pizza)
                .Include(p => p.PizzaBase)
                .Include(p => p.PizzaSize).FirstOrDefaultAsync(m => m.Id == id);

            if (PizzaOrder == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
