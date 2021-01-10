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
    public class IndexModel : PageModel
    {
        private readonly PizzaLoco.Data.PizzaLocoContext _context;

        public IndexModel(PizzaLoco.Data.PizzaLocoContext context)
        {
            _context = context;
        }

        public IList<PizzaOrder> PizzaOrder { get;set; }
        public PizzaData PizzaOrderD { get; set; }
        public int PizzaOrderId { get; set; }
        public int ToppingId { get; set; }


        public async Task OnGetAsync(int? id, int? toppingId)
        {
            PizzaOrderD = new PizzaData();

            PizzaOrderD.PizzaOrders = await _context.PizzaOrder
                .Include(p => p.Client)
                .Include(p => p.Pizza)
                .Include(p => p.PizzaBase)
                .Include(p => p.PizzaSize)
                .Include(p => p.PizzaToppings)
                .ThenInclude(p => p.Topping)
                .AsNoTracking()
                .ToListAsync();

            if (id != null)
            {
                PizzaOrderId = id.Value;
                PizzaOrder pizzaorder = PizzaOrderD.PizzaOrders
                .Where(i => i.Id == id.Value).Single();
                PizzaOrderD.Toppings = pizzaorder.PizzaToppings.Select(s => s.Topping);
            }

        }
    }
}
