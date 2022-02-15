using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class StudentOperations
    {
        public List<Student> GetAllStudentsOfSex(IEnumerable<Student> students, Geslacht geslacht)
        {
            return students.Where(s => s.Geslacht == geslacht).ToList();
        }
    }
}
