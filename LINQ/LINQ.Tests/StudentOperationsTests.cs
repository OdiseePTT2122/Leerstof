using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Tests
{
    [TestFixture]
    internal class StudentOperationsTests
    {
        List<Student> students;
        StudentOperations sut;

        [SetUp]
        public void Setup()
        {
            sut = new StudentOperations();

            students = new List<Student>()
            {
                new Student("Jan", "Janssens", 23, Geslacht.Mannelijk),
                new Student("Piet", "Potter", 18, Geslacht.Vrouwelijk),
                new Student("Andy", "Weir", 25, Geslacht.Anders),
                new Student("Dkj;", "kj;adf", 35, Geslacht.Mannelijk)
            };
        }

        [Test]
        public void GetAllStudentsOfSex_WithListOfMultipleSexes_ReturnOnlyMales()
        {
            // Arrange
            List<Student> expected = new List<Student>()
            {
                new Student("Jan", "Janssens", 23, Geslacht.Mannelijk),
                new Student("Dkj;", "kj;adf", 35, Geslacht.Mannelijk)
            };

            // Act
            List<Student> result = sut.GetAllStudentsOfSex(students, Geslacht.Mannelijk);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

    }
}
