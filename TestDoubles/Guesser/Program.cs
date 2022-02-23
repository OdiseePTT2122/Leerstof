using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guesser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HigherLower higherLower = new HigherLower();
            string result = "";

            do
            {
                Console.WriteLine("Raad het nummer");
                string input = Console.ReadLine();

                int number;
                if (int.TryParse(input, out number))
                {

                    result = higherLower.MakeAGuess(number);
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("Invalid entry");
                }

            } while (result != "Correct");

            Console.ReadLine();
        }
    }
}
