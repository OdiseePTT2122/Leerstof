using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotes
{
    public class Viewmodel
    {
        public string Auteur { get; set; }
        public string Quote { get; set; }

        public List<Quote> Quotes { get; set;}

        public Viewmodel()
        {
            Quotes = new List<Quote>();
            Auteur = "";
            Quote = "";
        }
    }
}
