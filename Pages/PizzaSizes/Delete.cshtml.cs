using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaLoco.Data;
using PizzaLoco.Models;

namespace PizzaLoco.Pages.PizzaSizes
{
    public class DeleteModel : PageModel
    {
        private readonly PizzaLoco.Data.PizzaLocoContext _context;

        public DeleteModel(PizzaLoco.Data.PizzaLocoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PizzaSize PizzaSize { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PizzaSize = await _context.PizzaSize.FirstOrDefaultAsync(m => m.PizzaSizeId == id);

            if (PizzaSize == null)
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

            PizzaSize = await _context.PizzaSize.FindAsync(id);

            if (PizzaSize != null)
            {
                _context.PizzaSize.Remove(PizzaSize);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
