using ProgrammingTask.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProgrammingTask.Repository
{
    public class TextFileParser : ITextFileParser
    {
        public void CreateTextFile(string text, string fileName)
        {
            File.WriteAllText(fileName, text);
        }

        public List<PersonScoreEntity> GetScoresFromFile(string fileName)
        {
            if (!File.Exists(fileName))
                throw new Exception($"Input file name doesn't exist. Please make sure you have written the whole route including location and extension: {fileName}");
            var peopleScores = File.ReadAllLines(fileName);
            var entities = new List<PersonScoreEntity>();
            foreach (var personScore in peopleScores)
            {
                var entityProperties = personScore.Split(',', StringSplitOptions.RemoveEmptyEntries);
                decimal.TryParse(entityProperties[2], out decimal score);
                var entity = new PersonScoreEntity
                {
                    FirstName = entityProperties[0],
                    LastName = entityProperties[1],
                    Score = score
                };
                entities.Add(entity);
            }
            return entities;
        }
    }
}
