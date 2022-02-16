using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEF
{
    internal class UserContext: DbContext
    {
        public UserContext()
            : base("users")
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
