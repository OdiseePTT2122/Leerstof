using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Code_First
{
    internal class UserContext: DbContext
    {
        // aan base moet er de connection string meegegeven worden (users is gedefineerd in de app.config)
        public UserContext()
            :base("users")
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<Car> cars { get; set; }

        // Hier kan je fluent api zaken gaan configureren
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.FirstName).IsUnicode(false);
            //[Required]
            modelBuilder.Entity<User>().Property(x => x.LastName).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.LastName).HasMaxLength(50);

            // foreign keys - many - op - many relatie (N op N)
            modelBuilder.Entity<User>().HasMany<Car>(user => user.Cars).WithMany(car => car.Gebruikers);

        }
    }
}
