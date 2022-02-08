using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests
{
    [TestFixture]
    internal class StoreTests
    {
        [Test]
        public void AddInventory_AddItemWithPositiveHoeveelheid_ProductAdded()
        {
            //Arrange
            Store sut = new Store();
            sut.AddInventory(Product.Chicken, 5);
            sut.AddInventory(Product.Chicken, 5);

            //Act
            int quantity = sut.GetInventory(Product.Chicken);

            //Assert
            Assert.That(quantity, Is.EqualTo(10));

        }
    }
}
