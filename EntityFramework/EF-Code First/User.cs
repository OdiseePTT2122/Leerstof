using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Code_First
{
    // Table dient om de naam van de tabel vast te leggen
    // Niet verplicht, default wordt de naam van de klasse genomen
    [Table("Gebruikers")]
    public class User
    {
        public User()
        {
            Cars = new List<Car>();
        }

        public User(string voornaam, string achternaam)
        {
            FirstName = voornaam;
            LastName = achternaam;
            Cars = new List<Car>();
        }

        // key == primary key
        [Key]
        public int Id { get; set; }

        // required == not null
        // Column == vastleggen van de kolomnaam (standaard is het de naam van de property zelf)
        // stringlength 50 -> max 50 karakters
        [Required]
        [Column("Voornaam")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Column("Achternaam")]
        [StringLength(200)]
        //[NotMapped] -> wordt niet opgeslagen in de database
        public string LastName { get; set; }

        public List<Car> Cars { get; set; }


    }
}