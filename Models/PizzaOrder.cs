using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaLoco.Models
{
    public class PizzaOrder
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        public int PizzaBaseId { get; set; }
        public PizzaBase PizzaBase { get; set; }
        public int PizzaSizeId { get; set; }
        public PizzaSize PizzaSize { get; set; }

        [Range(1, 20)]
        [Required]
        public int Quantity { get; set; }

#nullable enable
        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }
#nullable disable

        [Display(Name = "Toppings")]
        public ICollection<PizzaTopping> PizzaToppings { get; set; }
    }
}
