using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sound
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ISound> list = new List<ISound>()
            {
                new Cat(),
                new Dog(),
                new Human()
            };

            foreach (ISound sound in list)
            {
                sound.MakeNoise();
            }

            Console.ReadLine();
        }
    }
}
