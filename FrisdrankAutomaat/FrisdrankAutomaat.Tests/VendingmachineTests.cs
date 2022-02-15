using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrisdrankAutomaat.Tests
{
    [TestFixture]
    internal class VendingmachineTests
    {
        [TestCase(11,3)]
        [TestCase(7,9)]
        public void Buy_RowOrColumnTooLarge_ThrowsIndexOutOfRangeException(int row, int col)
        {
            //Arrange
            Vendingmachine sut = new Vendingmachine();

            //Act + Assert
            Assert.Throws<IndexOutOfRangeException>(() =>sut.buy(row, col));
        }

        [Test]
        public void Buy_SufficientBudgetAndDrinkPresent_ReturnsDrink()
        {
            //Arrange
            Vendingmachine sut = new Vendingmachine();
            Drink cola = new Drink("cola", 1.5);
            sut.AddDrink(cola, 2, 3);
            sut.InsertCoins(Coins.TWOEURO);

            //Act
            Drink result = sut.buy(2, 3);

            //Assert
            Assert.That(result, Is.EqualTo(cola));
            Assert.That(sut.Budget, Is.EqualTo(0.5));
            Assert.That(sut.Inventory[(2,3)], Is.EqualTo(null));
        }
    }
}
