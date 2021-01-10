using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaLoco.Data;
using PizzaLoco.Models;

namespace PizzaLoco.Pages.PizzaSizes
{
    public class EditModel : PageModel
    {
        private readonly PizzaLoco.Data.PizzaLocoContext _context;

        public EditModel(PizzaLoco.Data.PizzaLocoContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PizzaSize).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaSizeExists(PizzaSize.PizzaSizeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PizzaSizeExists(int id)
        {
            return _context.PizzaSize.Any(e => e.PizzaSizeId == id);
        }
    }
}
