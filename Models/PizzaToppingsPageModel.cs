using PizzaLoco.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaLoco.Models
{
    public class PizzaToppingsPageModel : PageModel
    {
        public List<AssignedToppingData> AssignedToppingDataList;
        public void PopulateAssignedToppingData(PizzaLocoContext context,
        PizzaOrder pizzaorder)
        {
            var allToppings = context.Topping;
            var pizzaToppings = new HashSet<int>(
            pizzaorder.PizzaToppings.Select(c => c.PizzaOrderId));
            AssignedToppingDataList = new List<AssignedToppingData>();
            foreach (var topp in allToppings)
            {
                AssignedToppingDataList.Add(new AssignedToppingData
                {
                    ToppingId = topp.Id,
                    Name = topp.Name,
                    Assigned = pizzaToppings.Contains(topp.Id)
                });
            }
        }
        public void UpdatePizzaToppings(PizzaLocoContext context,
        string[] selectedToppings, PizzaOrder pizzaToUpdate)
        {
            if (selectedToppings == null)
            {
                pizzaToUpdate.PizzaToppings = new List<PizzaTopping>();
                return;
            }
            var selectedToppingsHS = new HashSet<string>(selectedToppings);
            var pizzaToppings = new HashSet<int>
            (pizzaToUpdate.PizzaToppings.Select(c => c.Topping.Id));
            foreach (var topp in context.Topping)
            {
                if (selectedToppingsHS.Contains(topp.Id.ToString()))
                {
                    if (!pizzaToppings.Contains(topp.Id))
                    {
                        pizzaToUpdate.PizzaToppings.Add(
                        new PizzaTopping
                        {
                            PizzaOrderId = pizzaToUpdate.Id,
                            ToppingId = topp.Id
                        });
                    }
                }
                else
                {
                    if (pizzaToppings.Contains(topp.Id))
                    {
                        PizzaTopping courseToRemove
                        = pizzaToUpdate
                        .PizzaToppings
                        .SingleOrDefault(i => i.ToppingId == topp.Id);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
