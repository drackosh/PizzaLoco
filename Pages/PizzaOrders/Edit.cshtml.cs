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

namespace PizzaLoco.Pages.PizzaOrders
{
    public class EditModel : PizzaToppingsPageModel
    {
        private readonly PizzaLoco.Data.PizzaLocoContext _context;

        public EditModel(PizzaLoco.Data.PizzaLocoContext context)
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
                .Include(p => p.PizzaSize)
                .Include(p => p.PizzaToppings).ThenInclude(p => p.Topping)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (PizzaOrder == null)
            {
                return NotFound();
            }
            PopulateAssignedToppingData(_context, PizzaOrder);
            ViewData["ClientId"] = new SelectList(_context.Set<Client>(), "ClientId", "FullName");
            ViewData["PizzaId"] = new SelectList(_context.Set<Pizza>(), "PizzaId", "Name");
            ViewData["PizzaBaseId"] = new SelectList(_context.Set<PizzaBase>(), "PizzaBaseId", "Name");
            ViewData["PizzaSizeId"] = new SelectList(_context.Set<PizzaSize>(), "PizzaSizeId", "Size");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedToppings)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pizzaToUpdate = await _context.PizzaOrder
            .Include(i => i.Client)
            .Include(i => i.Pizza)
            .Include(i => i.PizzaBase)
            .Include(i => i.PizzaSize)
            .Include(i => i.PizzaToppings)
            .ThenInclude(i => i.Topping)
            .FirstOrDefaultAsync(s => s.Id == id);
            if (pizzaToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<PizzaOrder>(
            pizzaToUpdate,
            "PizzaOrder",
            i => i.ClientId, i => i.PizzaId,
            i => i.PizzaBaseId, i => i.PizzaSizeId, i => i.Quantity, i => i.OrderDate))
            {
                UpdatePizzaToppings(_context, selectedToppings, pizzaToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdatePizzaToppings(_context, selectedToppings, pizzaToUpdate);
            PopulateAssignedToppingData(_context, pizzaToUpdate);
            return Page();
        }

        private bool PizzaOrderExists(int id)
        {
            return _context.PizzaOrder.Any(e => e.Id == id);
        }
    }
}
