using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD
{
    public class Slot
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int SlotNumber { get; set; }
        public int Quantity { get; set; }

        public Slot(string name, double price, int slotNumber, int quantity)
        {
            Name = name;
            Price = price;
            SlotNumber = slotNumber;
            Quantity = quantity;
        }

        public override bool Equals(object obj)
        {
            Slot slot = obj as Slot;
            return slot.Name == Name && slot.Price == Price && slot.SlotNumber == SlotNumber && slot.Quantity == Quantity;
        }
    }
}
