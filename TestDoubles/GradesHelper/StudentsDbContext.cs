using System.Data.Entity;

namespace GradesHelper
{
    public class StudentsDbContext: DbContext
    {
        public StudentsDbContext():base("students")
        {

        }

        // om deze klasse te kunnen mocken moet dit virtual zijn
        public virtual DbSet<Student> Students { get; set; }
    }
}
