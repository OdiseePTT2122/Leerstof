﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesHelper.Tests
{
    internal class GradesRepositorySpy : IGradeRepository
    {
        public bool AddScoreIsCalled { get; private set; }

        public int LatestAddedScoreIs { get; private set; }

        public GradesRepositorySpy()
        {
            AddScoreIsCalled = false;
            LatestAddedScoreIs = -1;
        }

        public void AddScore(Student student, int score)
        {
            AddScoreIsCalled = true;
            LatestAddedScoreIs = score;
        }

        public void ClearScore(Student student)
        {
            throw new NotImplementedException();
        }

        public List<int> GetGrades(Student student)
        {
            throw new NotImplementedException();
        }

        public int GetTotalScore(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
