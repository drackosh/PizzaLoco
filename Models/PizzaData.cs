using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaLoco.Models
{
    public class PizzaData
    {
        public IEnumerable<PizzaOrder> PizzaOrders { get; set; }
        public IEnumerable<Topping> Toppings { get; set; }
        public IEnumerable<PizzaTopping> PizzaToppings { get; set; }
    }
}
