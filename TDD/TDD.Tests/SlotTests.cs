using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Tests
{
    [TestFixture]
    internal class SlotTests
    {
        [Test]
        [TestCase(2.2, "cola", 2, 5)]
        [TestCase(1.5, "water", 3, 10)]
        public void Ctor_WithValidData_AllPropertiesFilled(double price, string name, int slotNumber, int quantity)
        {
            // Arrange
        
            // Act
            Slot slot = new Slot(name, price, slotNumber, quantity);

            // Assert
            Assert.That(slot.Name, Is.EqualTo(name));
            Assert.That(slot.Price, Is.EqualTo(price));
            Assert.That(slot.SlotNumber, Is.EqualTo(slotNumber));
            Assert.That(slot.Quantity, Is.EqualTo(quantity));
        }
    }
}
