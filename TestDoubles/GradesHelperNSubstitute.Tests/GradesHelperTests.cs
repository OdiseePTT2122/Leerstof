using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace GradesHelper.Tests
{
    [TestFixture]
    internal class GradesHelperTests
    {
        [Test]
        public void CalcAverageGrade_WithList_ReturnsCorrectAverage()
        {
            // Stub

            // Arrange
            IGradeRepository stub = Substitute.For<IGradeRepository>();
            List<int> scores = new List<int> { 2, 4, 6, 8, 10, 12, 14, 16, 18 };
            List<int> scores2 = new List<int> {  8 };

            // doen hetzelfde
            // geven scores terug voor alle inputs
            //stub.GetGrades(default).ReturnsForAnyArgs(scores);
            //stub.GetGrades(Arg.Any<Student>()).Returns(scores);

            // specifiek voor 1 input
            Student student = new Student();
            Student student2 = new Student();
            /*stub.GetGrades(student).Returns(scores);
            stub.GetGrades(student2).Returns(scores2);*/

            // derde manier, iteratieve manier
            // eerste keer gecalled scores
            // tweede keer scores2 of het tweede argument
            // nog meer, altijd het laatste returnen
            stub.GetGrades(default).ReturnsForAnyArgs(scores, scores2);

            GradesHelper sut = new GradesHelper(stub);

            // Act
            double result = sut.CalcAverageGrade(student);
            double result2 = sut.CalcAverageGrade(student2);
            double result3 = sut.CalcAverageGrade(student);

            // Assert
            Assert.That(result, Is.EqualTo(10));
            Assert.That(result2, Is.EqualTo(8));
            Assert.That(result3, Is.EqualTo(8));
        }

        [Test]
        public void DidStudentPerformBetterWithNewScore_ScoreLargerThanAverage_ReturnTrue()
        {
            // fake
           
            // Arrange
            IGradeRepository fake = Substitute.For<IGradeRepository>();
            List<int> scores = new List<int> { 2, 4, 6, 8, 10, 12, 14, 16, 18 };
            int newScore = 12;
            // When: wanneer dit gebeurt (AddScore) opgeroepen
            // Do: Wat er dan gebeurt. In dit geval gaan we het 2e argument in scores toevoegen
            fake.When(x=>x.AddScore(Arg.Any<Student>(), Arg.Any<int>()))
                .Do(x=>scores.Add(x.ArgAt<int>(1)));
            fake.GetGrades(null).Returns(scores);
            // dit kan veiliger zijn om zeker de laatste update te hebben
            fake.GetGrades(null).Returns(x=>scores);

            GradesHelper sut = new GradesHelper(fake);

            // Act
            bool result = sut.DidStudentPerformBetterWithNewScore(null, newScore);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void RemoveAllScores_ClearScoreIsCalled()
        {
            // Arrange 
            IGradeRepository spy = Substitute.For<IGradeRepository>();

            GradesHelper sut = new GradesHelper(spy);

            // Act
            sut.RemoveAllScores(null);

            // Assert
            // dit telt alle argumenten
            spy.Received().ClearScore(Arg.Any<Student>());
            // dit telt enkel het argument null
            spy.Received().ClearScore(null);
        }

        [Test]
        public void RemoveAllScores_ClearScoreIsCalled_WithMock()
        {
            // Arrange 
            IGradeRepository mock = Substitute.For<IGradeRepository>();
            mock.When(x => x.ClearScore(Arg.Any<Student>())).Do(x => Assert.Pass());
            GradesHelper sut = new GradesHelper(mock);

            // Act
            sut.RemoveAllScores(null);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void AddScore_WithInvalidScore_AddScoreNotCalled()
        {
            // Arrange 
            IGradeRepository spy = Substitute.For<IGradeRepository>();

            GradesHelper sut = new GradesHelper(spy);

            // Act
            Assert.Throws<Exception>(()=>sut.AddScore(null, -5));

            // Assert
            spy.DidNotReceive().AddScore(null, Arg.Any<int>());
        }
    }
}
