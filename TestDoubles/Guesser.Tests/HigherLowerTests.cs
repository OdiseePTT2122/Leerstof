using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace Guesser.Tests
{
    [TestFixture]
    internal class HigherLowerTests
    {
        [Test]
        public void MakeAGuess_WithLowerGuess_ReturnsHigher()
        {
            //Arrange
            IRandom random = Substitute.For<IRandom>();
            random.Next(Arg.Any<int>()).Returns(50);
            HigherLower sut = new HigherLower(random);
            int guess=10;

            //Act
            string result = sut.MakeAGuess(guess);

            // Assert
            Assert.That(result, Is.EqualTo("Higher"));

        }


        [Test]
        public void MakeAGuess_WithHigherGuess_ReturnsHigher()
        {

        }


        [Test]
        public void MakeAGuess_WithCorrectGuess_ReturnsCorrect()
        {

        }
    }
}
