using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // oude manier van testen
            Calculator calculator = new Calculator();
            Console.WriteLine(calculator.Sum(5, 10));
            Console.ReadLine();

            // nieuwe manier van testen
            // maak apart project aan
            // class library .net framework
                // NuGet packages toevoegen
                    // NUnit
                    // NUnit3TestAdapter
                // Add project reference to this project
                // Zorg ervoor dat de te testen klasse public is
        }
    }
}
