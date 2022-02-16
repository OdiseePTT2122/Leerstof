using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DatabaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentContext studentContext = new StudentContext();
            /*
            Student student = new Student();
            student.Id = 1;
            student.Naam = "Jan";
            student.Score = 15;

            Student student2 = new Student();
            student2.Id = 2;
            student2.Naam = "Jan2";
            student2.Score = 5;

            Student student3 = new Student();
            student3.Id = 3;
            student3.Naam = "Jan3";
            student3.Score = 12;

            studentContext.Students.Add(student);
            studentContext.Students.Add(student2);
            studentContext.Students.Add(student3);

            studentContext.SaveChanges();

            Console.WriteLine(studentContext.Students.Count());*/

            Console.WriteLine(studentContext.Students.Average(x=>x.Score));

            // change data
            Student student = studentContext.Students.First(x => x.Id == 3);
            student.Score = 18;
            studentContext.SaveChanges();

            foreach(var s in studentContext.Students)
            {
                Console.WriteLine(s.Score);
            }

            // remove data
            student = studentContext.Students.First(x => x.Id == 2);
            studentContext.Students.Remove(student);
            studentContext.SaveChanges();

            Console.ReadLine();
        }
    }
}
