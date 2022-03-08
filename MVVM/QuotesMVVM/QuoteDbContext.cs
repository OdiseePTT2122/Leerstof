
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesMVVM
{
    public class QuoteDbContext: DbContext
    {
        public QuoteDbContext():base("quotes")
        {
        }


        public virtual DbSet<Quote> Quotes { get; set; }

    }
}
