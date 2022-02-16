using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Code_First
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            UserContext userContext = new UserContext();
            
            User user = new User("Jens", "Baetens");
            Car car = new Car("Ferrari");

            car.Gebruikers.Add(user);
            user.Cars.Add(car);

            userContext.users.Add(user);
            userContext.cars.Add(car);

            userContext.SaveChanges();*/

            UserRepository userRepository = new UserRepository();
            List<User> users = userRepository.GetAllUsersWithCars();
        }
    }
}
