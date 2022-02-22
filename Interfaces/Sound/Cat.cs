using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sound
{
    internal class Cat : ISound
    {
        public void MakeNoise()
        {
            Console.WriteLine("miauw");
        }
    }
}
