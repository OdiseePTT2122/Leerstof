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
            Calculator sut = new Calculator();

            int result = sut.Sum(5, 10);

            Assert.AreEqual(5, result);
        }
    }
}
