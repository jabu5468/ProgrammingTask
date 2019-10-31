using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProgrammingTask.Models;

namespace ProgrammingTask.Service
{
    public class PeopleScoresProcessor : IPeopleScoresProcessor
    {
        public string GetTopScoringPeople(List<PersonScoreEntity> peopleScores)
        {
            var orderedPeopleScores = peopleScores.OrderByDescending(x => x.Score);
            var highestScoringPerson = orderedPeopleScores.FirstOrDefault();
            if(highestScoringPerson != null)
            {
                var builder = new StringBuilder();
                var highestScoringPeople = peopleScores.Where(x => x.Score == highestScoringPerson.Score).ToList();
                foreach(var highScorer in highestScoringPeople)
                {
                    builder.AppendLine($"{highScorer.FirstName} {highScorer.LastName}");
                }
                return builder.ToString();
            }
            return string.Empty;
        }
    }
}
