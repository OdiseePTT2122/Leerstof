using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests;

namespace UnitTests.Tests
{
    // TestFixture -> zorgt ervoor dat de test-runner gaat kijken in deze klasse naar tests
    [TestFixture]
    class CalculatorTests
    {
        // Test -> deze functie is een test, naamgeving is Functie_Scenario_VerwachtGedrag
        [Test]
        public void Sum_GivenTwoPositiveNumbers_ReturnCorrectSum()
        {
            //Arrange
            Calculator sut = new Calculator();

            //Act
            int result = sut.Sum(5, 10);

            //Assert
            Assert.AreEqual(15, result);
        }

        [Test]
        public void Divide_GivenTwoDivisibleIntegers_ReturnDivision()
        {
            //Arrange - doe de setup
            Calculator sut = new Calculator();  // subject under test = sut

            //Act - voer iets uit
            int result = sut.Divide(10, 5);

            //Assert - controleer de output van de act
            Assert.AreEqual(2, result);
            Assert.That(result, Is.EqualTo(2));
        }
    }
}
