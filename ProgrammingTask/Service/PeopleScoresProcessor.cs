using System.Collections.Generic;
using System.Text;
using ProgrammingTask.Models;

namespace ProgrammingTask.Service
{
    public class PeopleScoresProcessor : IPeopleScoresProcessor
    {
        public string GetTopScoringPeople(List<PersonScoreEntity> peopleScores)
        {
            decimal highestMark = 0;
            var highestScorers = new List<PersonScoreEntity>();

            foreach(var personScore in peopleScores)
            {
                if (personScore.Score > highestMark) {
                    highestMark = personScore.Score;
                    highestScorers = new List<PersonScoreEntity>
                    {
                        personScore
                    };
                }
                else if (personScore.Score == highestMark)
                {
                    highestScorers.Add(personScore);
                }

            }

            var builder = new StringBuilder();
            foreach (var highScorer in highestScorers)
            {
                builder.AppendLine($"{highScorer.FirstName} {highScorer.LastName}");
            }
            return builder.ToString();
        }
    }
}
