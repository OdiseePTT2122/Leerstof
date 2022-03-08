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
            // Het probleem met de standaard manier van Is.EqualTo was dat ik aparte objecten aanmaakte,
            // als je de objecten uit de origenele lijst haalt zoals hieronder moet je de Equals Operator niet overloaden.

            // Arrange
            List<Student> expected = new List<Student>()
            {
                students[0],
                students[3]
            };

            // Act
            List<Student> result = sut.GetAllStudentsOfSex(students, Geslacht.Mannelijk);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetAllStudentsOfSex_WithListOfMultipleSexes_ReturnOnlyMales2()
        {
            // Indien je voor het maken van de expected list nieuwe objecten aanmaakt
            // moet je ook ervoor zorgen dat je ook de Equals Operator overload.

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

            List<int> numbers = new List<int>();

            numbers.Select(x =>
            {
                if(x%2 == 0)
                {
                    return x * x;
                } else
                {
                    return x;
                }
            })

        }

    }
}
