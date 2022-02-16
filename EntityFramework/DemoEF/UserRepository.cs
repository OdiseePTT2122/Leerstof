using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEF
{
    internal class UserRepository
    {
        private UserContext userContext = new UserContext();
        
        public List<User> GetAllUsers()
        {
            return userContext.Users.ToList();
        }

        public void InsertUser(User user)
        {
            userContext.Users.Add(user);
            userContext.SaveChanges();
        }
    }
}
