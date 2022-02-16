using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*List<int> getallen = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int sum = 0;
            foreach(var getal in getallen)
            {
                sum += getal;
            }

            //Console.WriteLine(sum / getallen.Count);

            Console.WriteLine(getallen.Average());
            Console.WriteLine(getallen.Sum());
            Console.WriteLine(getallen.Min());
            Console.WriteLine(getallen.Max());

            var list = getallen.Where(x => x % 2 == 0);

            Console.WriteLine(); */

            List<Student> students = new List<Student>()
            {
                new Student("Jan", "Janssens", 23, Geslacht.Mannelijk),
                new Student("Piet", "Potter", 18, Geslacht.Vrouwelijk),
                new Student("Andy", "Weir", 25, Geslacht.Anders),
                new Student("Dkj;", "kj;adf", 35, Geslacht.Mannelijk)
            };

            if(students[0] == students[1])
            {

            }

            int sum = 0;
            foreach (var student in students)
            {
                sum += student.Age;
            }

            Console.WriteLine(sum / students.Count);

            // Je geeft een functie mee die zegt hoe het Student object omgezet wordt naar een getalletje om er het average van te berekenen
            students.Average(GetAge);

            // nieuwere manier - lambda expressions
            students.Average(s => s.Age);

            // only select the lastname
            //IEnumerable<string> lastnames = students.Select((Student s) => { return s.LastName; });
            IEnumerable<string> lastnames = students.Select(s => s.LastName);
            foreach (var x in lastnames)
            {
                Console.WriteLine(x);
            }

            // meest algemene vorm
            //(/*inputs*/s1, s2, s3) => { /*statements*/ Console.WriteLine(s1); s2 + s3; };
            // vorige
            // als er 1 statement is -> zijn de acolades niet nodig
            //(/*inputs*/s1, s2, s3) => Console.WriteLine(s1);
            // als er 1 input is -> zijn de haakjes niet nodig
            //s1 => s1.LastName;

            List<int> getallen = new List<int> { 1, 2, 30, 4, 5, 6, 7, 8, 9 };
            // filter alles dat groter is dan 5: daar kan je de Where voor gebruiken
            IEnumerable<int> result = getallen.Where(x => x > 5);
            // 50 komt niet automatisch in result 
            getallen.Add(50);

            // zoek alle mannelijke studenten ouder dan 24
            List<Student> result1 = students.Where(x => x.Geslacht == Geslacht.Mannelijk && x.Age > 24).ToList();

            // Select
            // where gaat objecten gaan filteren
            // select iets gaan filteren van object
            getallen.Select(x => x + x);

            // lijst met studenten: wat is de "voornaam achternaam"
            IEnumerable<string> results = students.Select(x => x.LastName + " " + x.FirstName);

            // Method chaining - LINQ queries kunnen opgeroepen worden op  het resultaat van een andere LINQ query
            IEnumerable<string> results2 = students.Where(x => x.Geslacht == Geslacht.Vrouwelijk).Select(x => x.LastName + " " + x.FirstName);

            // OrderBy (lambda expressie noodzakelijk)
            var res = getallen.OrderBy(x => x);
            res = getallen.OrderByDescending(x => x);

            foreach (var x in res)
            {
                Console.WriteLine(x);
            }

            Console.ReadKey();
        }

        public static int GetAge(Student s)
        {
            return s.Age;
        }
    }
}
