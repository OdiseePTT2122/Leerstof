﻿using System;

namespace Guesser
{
    public class HigherLower
    {
        int number;
      
        public HigherLower()
        {
            Random random = new Random();
            number = random.Next(100);
        }

        public string MakeAGuess(int guess)
        {
            if (number == guess)
            {
                return "Correct";
            }
            else if (number < guess)
            {
                return "Lower";
            }
            else
            {
                return "Higher";
            }
        }
    }
}
