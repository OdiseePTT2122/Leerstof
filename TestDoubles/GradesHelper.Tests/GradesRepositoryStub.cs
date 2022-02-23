using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesHelper.Tests
{
    internal class GradesRepositoryStub : IGradeRepository
    {
        public void AddScore(Student student, int score)
        {
            throw new NotImplementedException();
        }

        public void ClearScore(Student student)
        {
            throw new NotImplementedException();
        }

        public List<int> GetGrades(Student student)
        {
            return new List<int> { 2,4,6,8,10,12,14,16,18 };
        }

        public int GetTotalScore(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
