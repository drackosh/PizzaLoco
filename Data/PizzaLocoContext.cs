using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaLoco.Models;

namespace PizzaLoco.Data
{
    public class PizzaLocoContext : DbContext
    {
        public PizzaLocoContext (DbContextOptions<PizzaLocoContext> options)
            : base(options)
        {
        }

        public DbSet<PizzaLoco.Models.PizzaOrder> PizzaOrder { get; set; }

        public DbSet<PizzaLoco.Models.Client> Client { get; set; }

        public DbSet<PizzaLoco.Models.Pizza> Pizza { get; set; }

        public DbSet<PizzaLoco.Models.PizzaBase> PizzaBase { get; set; }

        public DbSet<PizzaLoco.Models.PizzaSize> PizzaSize { get; set; }

        public DbSet<PizzaLoco.Models.Topping> Topping { get; set; }
    }
}
