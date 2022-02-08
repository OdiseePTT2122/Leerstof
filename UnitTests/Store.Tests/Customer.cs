using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests
{
    public class Customer
    {
        private Dictionary<Product, int> basket = new Dictionary<Product, int>();

        public Dictionary<Product, int> Basket { get => basket; set => basket = value;}

        public bool Purchase(Store store, Product product, int quantity)
        {
            if(store.HasInventory(product, quantity))
            {
                store.RemoveInventory(product, quantity);
                basket.Add(product, quantity);
                return true;
            }

            return false;
        }
    }
}
