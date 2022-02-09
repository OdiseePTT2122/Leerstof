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

        [Test]
        public void GetInventory_UnknownProduct_ThrowsException()
        {
            //Arrange
            Store sut = new Store();

            //Act
            /*try
            {
                sut.GetInventory(Product.Shampoo);
                Assert.Fail();
            } catch (Exception ex)
            {
                Assert.Pass();
            }*/

            // () => sut.GetInventory(Product.Shampoo) is een lambda expressie
            // dit is een tijdelijke, naamloze functie
            // het deel voor de pijl zijn de parameters
            // het deel na de pijl de body van de functie ({} voor meerdere lijnen)
            Assert.Throws<KeyNotFoundException>(() => sut.GetInventory(Product.Shampoo));
            // dit is het assert gedeelte              dit is de act

            //controleren dat er geen exception opgegooid wordt
            //Assert.DoesNotThrow(() => sut.GetInventory(Product.Shampoo));

            //Assert
        }
    }
}
