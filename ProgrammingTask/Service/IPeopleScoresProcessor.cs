using ProgrammingTask.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingTask.Service
{
    public interface IPeopleScoresProcessor
    {
        string GetTopScoringPeople(List<PersonScoreEntity> peopleScores);
    }
}
