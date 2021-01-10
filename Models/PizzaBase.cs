using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaLoco.Models
{
    public class PizzaBase
    {
        [Key]
        public int PizzaBaseId { get; set; }

        [StringLength(12, MinimumLength = 3)]
        [Display(Name = "Base")]
        [Required]
        public string Name { get; set; }

        public ICollection<PizzaOrder> PizzaOrders { get; set; }
    }
}
