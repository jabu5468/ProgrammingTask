using ProgrammingTask.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingTask.Repository
{
    public interface ITextFileParser
    {
        void CreateTextFile(string text, string name);
        List<PersonScoreEntity> GetScoresFromFile(string name);
    }
}
