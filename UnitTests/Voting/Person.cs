using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting
{
    public class Person
    {
        public int Age { get; set; }

        public Person(int age)
        {
            Age = age;
        }

        public bool CanVote()
        {
            // return Age ==18 || Age ==19;

            return Age >= 18 && Age<130;
        }
    }
}
