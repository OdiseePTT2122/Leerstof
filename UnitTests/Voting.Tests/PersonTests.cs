using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting.Tests
{
    [TestFixture]
    internal class PersonTests
    {
        /* [TestCase(18, "Jens")]
         [TestCase(23, "Jan")]
         [TestCase(19, "Piet")]
         [TestCase(64, "Pol")]
         public void CanVote_WithCorrectAge_ReturnsTrue(int age, string name)
         {
             //Arrange
             Person person = new Person(age);

             //Act
             bool result = person.CanVote();

             //Assert
             Assert.True(result);
         }

         [TestCase(4)]
         [TestCase(204)]
         public void CanVote_WithIncorrectAge_ReturnsFalse(int age)
         {
             //Arrange
             Person person = new Person(age);

             //Act
             bool result = person.CanVote();

             //Assert
             Assert.False(result);
         }
        */
        [TestCase(18, ExpectedResult =true)]
        [TestCase(23, ExpectedResult = true)]
        [TestCase(19, ExpectedResult = true)]
        [TestCase(64, ExpectedResult = true)]
        [TestCase(4, ExpectedResult = false)]
        [TestCase(204, ExpectedResult = false)]
        public bool CanVote_WithVariousAges_ReturnsFalseWhenLessThan18OrMoreThan130(int age)
        {
            //Arrange
            Person person = new Person(age);

            //Act
            bool result = person.CanVote();

            //Assert
            return result; // return result, wordt gecontroleerd met de expectedResult in de testcase
            // let op het return type moet correct zijn (geen void)
        }
    }
}
