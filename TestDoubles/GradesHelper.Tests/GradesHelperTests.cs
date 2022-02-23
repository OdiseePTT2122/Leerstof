using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesHelper.Tests
{
    [TestFixture]
    internal class GradesHelperTests
    {
        [Test]
        public void CalcAverageGrade_ListOfScores_ReturnsAverage()
        {
            // Dit test double type is een Stub

            // Arrange
            // dit gaat de database gaan aanspreken
            // resultaten gaan afhangen van wat er in de database zit
            // GradesHelper sut = new GradesHelper();
            GradesRepositoryStub stub = new GradesRepositoryStub();
            GradesHelper sut = new GradesHelper(stub);

            // Act
            double result = sut.CalcAverageGrade(null);
            // student wordt niet gebruikt dus kan null zijn

            // Assert
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void DidStudentPerformBetterWithNewScore()
        {
            // Fake

            // Arrange
            List<int> scores = new List<int> { 2, 4, 6, 8, 10, 12, 14, 16, 18 };
            GradesRepositoryFake fake = new GradesRepositoryFake(scores);
            GradesHelper sut = new GradesHelper(fake);

            // Act
            bool result = sut.DidStudentPerformBetterWithNewScore(null, 11);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void RemoveAllScores_ClearScoreIsCalled()
        {
            //Mock

            // Arrange
            GradesRepositoryMock mock = new GradesRepositoryMock();
            GradesHelper sut = new GradesHelper(mock);

            // Act
            sut.RemoveAllScores(null);

            // Assert
            // standaard gedrag is dat het slaagt als het einde van de test bereikt is zonder assert
            // we willen echter dat het faalt, tenzij de functie opgeroepen is.
            Assert.Fail();
        }

        [Test]
        public void AddScore_WithValidData_AddScoreIsCalled()
        {
            // Spy

            // Arrange
            GradesRepositorySpy spy = new GradesRepositorySpy();
            GradesHelper sut = new GradesHelper(spy);

            // Act
            sut.AddScore(null, 5);

            // Assert
            Assert.IsTrue(spy.AddScoreIsCalled);
            Assert.That(spy.LatestAddedScoreIs, Is.EqualTo(5));
        }

        [Test]
        public void AddScore_WithInvalidData_AddScoreIsCalled()
        {
            // Spy

            // Arrange
            GradesRepositorySpy spy = new GradesRepositorySpy();
            GradesHelper sut = new GradesHelper(spy);

            // Act
            Assert.Throws<Exception>(() => sut.AddScore(null, -5));

            // Assert
            Assert.IsFalse(spy.AddScoreIsCalled);
        }
    }
}
