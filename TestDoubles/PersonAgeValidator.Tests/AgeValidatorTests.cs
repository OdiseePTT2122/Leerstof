using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonAgeValidator.Tests
{
    [TestFixture]
    internal class AgeValidatorTests
    {
        [TestCase(17, ExpectedResult=false)]
        [TestCase(18, ExpectedResult = true)]
        [TestCase(30, ExpectedResult = true)]
        [TestCase(40, ExpectedResult = true)]
        [TestCase(70, ExpectedResult = true)]
        [TestCase(80, ExpectedResult = false)]
        public bool IsValidAge_VariousAges_ReturnsTrueWhenBetween18And70WithLimits(int age)
        {
            // Arrange
            AgeValidator sut = new AgeValidator();

            // Act
            bool result = sut.IsValidAge(age);

            // Assert
            return result;
        }
        
        
        
        
        
    }
}
