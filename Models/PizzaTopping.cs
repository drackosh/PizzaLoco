using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaLoco.Models
{
    public class PizzaTopping
    {
        public int Id { get; set; }
        public int PizzaOrderId { get; set; }
        public PizzaOrder PizzaOrder { get; set; }
        public int ToppingId { get; set; }
        public Topping Topping { get; set; }

    }
}
