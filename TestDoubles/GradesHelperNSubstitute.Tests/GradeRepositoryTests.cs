using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesHelper.Tests
{
    [TestFixture]
    internal class GradeRepositoryTests
    {
        List<Student> students = new List<Student>()
            {
                new Student()
                {
                    Id  =1,
                    FirstName = "John",
                    LastName = "Doe",
                    Scores = new List<int>(){1,2,3,4,5}
                },new Student()
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Scores = new List<int>(){5,6,7,8,9}
                }
            };

        [Test]
        public void GetGrades()
        {
            // Arrange
            // dit kan je doen omdat de DbSet virtual is!!!
            var dbContext = Substitute.For<StudentsDbContext>();
            // om te vermijden dat hier entityframework nodig is: ook substitute maken van DbSet
            var dbSetStudent = Substitute.For<DbSet<Student>, IQueryable<Student>>();
            ((IQueryable<Student>)dbSetStudent).Provider.Returns(students.AsQueryable().Provider);
            ((IQueryable<Student>)dbSetStudent).Expression.Returns(students.AsQueryable().Expression);
            ((IQueryable<Student>)dbSetStudent).GetEnumerator().Returns(students.AsQueryable().GetEnumerator());

            // students hier niet nodig (staat in de drie regels hierboven)
            dbContext.Students.Returns(dbSetStudent);
            // probleem hierbij -> link met database/ dbcontext doorbreken.
            GradeRepository sut = new GradeRepository(dbContext);

            // Act
            List<int> grades = sut.GetGrades(students[1]);

            // Assert
            Assert.That(grades, Is.EqualTo(students[1].Scores));
        }

        [Test]
        public void GetGrades2()
        {
            // Arrange
            // dit kan je doen omdat de DbSet virtual is!!!
            var dbContext = Substitute.For<StudentsDbContext>();
            var dbSetStudent = NSubstituteUtils.GenerateMockDbSet<Student>(students);
           
            // students hier niet nodig (staat in de drie regels hierboven)
            dbContext.Students.Returns(dbSetStudent);
            // probleem hierbij -> link met database/ dbcontext doorbreken.
            GradeRepository sut = new GradeRepository(dbContext);

            // Act
            List<int> grades = sut.GetGrades(students[1]);

            // Assert
            Assert.That(grades, Is.EqualTo(students[1].Scores));
        }
    }
}
