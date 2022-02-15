using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Geslacht Geslacht { get; set; }

        public Student(string firstname, string lastname, int age, Geslacht geslacht)
        {
            FirstName = firstname;
            LastName = lastname;
            Age = age;
            Geslacht = geslacht;
        }
    }
}
