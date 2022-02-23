using System.Data.Entity;

namespace GradesHelper
{
    public class StudentsDbContext: DbContext
    {
        public StudentsDbContext():base("students")
        {

        }

        public virtual DbSet<Student> Students { get; set; }
    }
}
