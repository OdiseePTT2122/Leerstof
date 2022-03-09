using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesCoordinator
{
    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }

        public Quote(string text, string author)
        {
            Text = text;
            Author = author;
        }

        public Quote()
        {

        }

            public override bool Equals(object obj)
        {
            if(obj is Quote)
            {
                Quote quote = (Quote)obj;
                return quote.Author == Author && quote.Text == Text;
            }
            return false;
        }
    }
}
