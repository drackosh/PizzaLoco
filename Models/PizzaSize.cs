using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaLoco.Models
{
    public class PizzaSize
    {
        [Key]
        public int PizzaSizeId { get; set; }

        [Required]
        [Range(1, 100)]
        public int Size { get; set; }

        public ICollection<PizzaOrder> PizzaOrders { get; set; }
    }
}
