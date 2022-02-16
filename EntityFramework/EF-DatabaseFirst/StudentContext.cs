using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EF_DatabaseFirst
{
    //DbContext staat voor database
    public partial class StudentContext : DbContext
    {
        // name zegt met welke database er geconnecteerd wordt
        public StudentContext()
            : base("name=StudentContext")
        {
        }

        // Elke DbSet komt overeen met een tabel
        public virtual DbSet<Student> Students { get; set; }

        // Hier kan je de constraints van de kolommen gaan aanpassen
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(e => e.Naam)
                .IsUnicode(false);
        }
    }
}
