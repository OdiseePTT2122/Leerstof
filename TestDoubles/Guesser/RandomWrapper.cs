using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guesser
{
    internal class RandomWrapper:IRandom
    {
        public int Next(int max)
        {
            Random random = new Random();
            return random.Next(100);
        }
    }
}
