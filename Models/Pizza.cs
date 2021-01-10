using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaLoco.Models
{
    public class Pizza
    {
        [Key]
        public int PizzaId { get; set; }

        [StringLength(20, MinimumLength = 8)]
        [Display(Name = "Pizza")]
        [Required]
        public string Name { get; set; }

        [StringLength(80, MinimumLength = 11)]
        [Required]
        public string Ingredients { get; set; }

        [Range(1, 150)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        public ICollection<PizzaOrder> PizzaOrders { get; set; }
    }
}
