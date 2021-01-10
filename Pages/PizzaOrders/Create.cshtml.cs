using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaLoco.Data;
using PizzaLoco.Models;

namespace PizzaLoco.Pages.PizzaOrders
{
    public class CreateModel : PizzaToppingsPageModel
    {
        private readonly PizzaLoco.Data.PizzaLocoContext _context;

        public CreateModel(PizzaLoco.Data.PizzaLocoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ClientId"] = new SelectList(_context.Set<Client>(), "ClientId", "FullName");
            ViewData["PizzaId"] = new SelectList(_context.Set<Pizza>(), "PizzaId", "Name");
            ViewData["PizzaBaseId"] = new SelectList(_context.Set<PizzaBase>(), "PizzaBaseId", "Name");
            ViewData["PizzaSizeId"] = new SelectList(_context.Set<PizzaSize>(), "PizzaSizeId", "Size");

            var pizzaorder = new PizzaOrder();
            pizzaorder.PizzaToppings = new List<PizzaTopping>();
            PopulateAssignedToppingData(_context, pizzaorder);

            return Page();
        }

        [BindProperty]
        public PizzaOrder PizzaOrder { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedToppings)
        {
            var newPizzaOrder = new PizzaOrder();
            if (selectedToppings != null)
            {
                newPizzaOrder.PizzaToppings = new List<PizzaTopping>();
                foreach (var topp in selectedToppings)
                {
                    var toppToAdd = new PizzaTopping
                    {
                        ToppingId = int.Parse(topp)
                    };
                    newPizzaOrder.PizzaToppings.Add(toppToAdd);
                }
            }
            if (await TryUpdateModelAsync<PizzaOrder>(
            newPizzaOrder,
            "PizzaOrder",
            i => i.ClientId, i => i.PizzaId,
            i => i.PizzaBaseId, i => i.PizzaSizeId, i => i.Quantity, i => i.OrderDate))
            {
                _context.PizzaOrder.Add(newPizzaOrder);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedToppingData(_context, newPizzaOrder);
            return Page();
        }
    }
}