using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;       // Niet vergeten deze using toe te voegen

namespace EF_Code_First
{
    public class UserRepository
    {
        private UserContext context = new UserContext();

        // crud-operaties (create - read - update - delete

        // create
        public void AddUser(User user)
        {
            context.users.Add(user);
            context.SaveChanges();
        }

        // read
        public List<User> GetAllUsers()
        {
            return context.users.ToList();
        }

        public List<User> GetAllUsersWithCars()
        {
            return context.users.Include(user => user.Cars).ToList();
        }

        // update
        public void UpdateUser(User user)
        {
            context.SaveChanges();
        }

        // delete
        public void DeleteUser(User user)
        {
            context.users.Remove(user);
            context.SaveChanges();
        }
    }
}
