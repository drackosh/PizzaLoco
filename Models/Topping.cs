using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaLoco.Models
{
    public class Topping
    {
        public int Id { get; set; }

        [StringLength(12, MinimumLength = 3)]
        public string Name { get; set; }
        public ICollection<PizzaTopping> PizzaTopping { get; set; }
    }
}
