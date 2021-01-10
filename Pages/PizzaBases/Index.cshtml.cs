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
    public class IndexModel : PageModel
    {
        private readonly PizzaLoco.Data.PizzaLocoContext _context;

        public IndexModel(PizzaLoco.Data.PizzaLocoContext context)
        {
            _context = context;
        }

        public IList<PizzaBase> PizzaBase { get;set; }

        public async Task OnGetAsync()
        {
            PizzaBase = await _context.PizzaBase.ToListAsync();
        }
    }
}
