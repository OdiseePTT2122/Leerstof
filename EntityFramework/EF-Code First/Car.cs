using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF_Code_First
{
    public class Car
    {
        public Car()
        {
             Gebruikers = new List<User>();
        }

        public Car(string merk)
        {
            Merk = merk;
            Gebruikers = new List<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Merk { get; set; }

        public string Model { get; set; }

        public List<User> Gebruikers { get; set; }


    }
}