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
    public class DeleteModel : PageModel
    {
        private readonly PizzaLoco.Data.PizzaLocoContext _context;

        public DeleteModel(PizzaLoco.Data.PizzaLocoContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PizzaOrder = await _context.PizzaOrder.FindAsync(id);

            if (PizzaOrder != null)
            {
                _context.PizzaOrder.Remove(PizzaOrder);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
