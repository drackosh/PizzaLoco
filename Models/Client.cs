using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaLoco.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [Display(Name = "Client")]
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele trebuie sa fie de forma 'Prenume Nume'"), Required, StringLength(50, MinimumLength = 3)]
        public string FullName { get; set; }

        [StringLength(40, MinimumLength = 10)]
        [Required]
        public string Address { get; set; }

        [StringLength(15, MinimumLength = 10)]
        [Required]
        public string Phone { get; set; }
#nullable enable
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
#nullable disable

        public ICollection<PizzaOrder> PizzaOrders { get; set; }
    }
}
