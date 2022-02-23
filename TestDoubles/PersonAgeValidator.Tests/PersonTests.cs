using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonAgeValidator.Tests
{
    [TestFixture]
    internal class PersonTests
    {
        // Dit gaan we moeten doen in twee testen
        // omdat het gedrag verschilt

        [TestCase(18)]
        [TestCase(30)]
        [TestCase(40)]
        [TestCase(70)]
        public void Ctor_ValidAge_ObjectCreated(int age)
        {
            // Arrange
            string firstname = "test";
            string lastname = "testlast";

            // Act
            Person person = new Person(firstname, lastname, age);

            // Assert
            Assert.That(person.FirstName, Is.EqualTo(firstname));
            Assert.That(person.LastName, Is.EqualTo(lastname));
            Assert.That(person.Age, Is.EqualTo(age));
            //Assert.Pass();    // Als we hier komen, slaagt de test
        }

        [TestCase(17)]
        [TestCase(10)]
        [TestCase(71)]
        [TestCase(80)]
        public void Ctor_InvalidAge_ExceptionThrown(int age)
        {
            // Arrange
            string firstname = "test";
            string lastname = "testlast";

            //Act + Assert
            Assert.Throws<Exception>(() => new Person(firstname, lastname, age));
        }
    }
}
