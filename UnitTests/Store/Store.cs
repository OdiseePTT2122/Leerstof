using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Store
    {
        // dictionary 
            // key1 -> value1
            // key2 -> value2
            // key3 -> value3

        // tussen <>
            // eerst is het type van de key (in dit geval Product)
            // int is het type van de values (in dit geval int)
        private Dictionary<Product, int> inventory = new Dictionary<Product, int>();

        public void AddInventory(Product product, int quantity)
        {
            // deze regel zegt, van dit type product (key) is de value = quantity
            if (inventory.ContainsKey(product))
            {
                inventory[product] += quantity;
            } else { 
                inventory[product] = quantity;
                //inventory.Add(product, quantity);
                //deze twee doen hetzelfde
            }
        }

        public void RemoveInventory()
        {

        }

        public int GetInventory(Product product)
        {
            // returned de value horende bij de key product
            return inventory[product];
        }

        public bool HasInventory()
        {
            return false;
        }
    }
}
