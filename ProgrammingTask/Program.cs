using Microsoft.Extensions.DependencyInjection;
using ProgrammingTask.Repository;
using ProgrammingTask.Service;
using System;
using System.Text;

namespace ProgrammingTask
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddScoped<ITextFileParser, TextFileParser>();
                serviceCollection.AddScoped<IPeopleScoresProcessor, PeopleScoresProcessor>();

                var serviceProvider = serviceCollection.BuildServiceProvider();

                var textFileParser = serviceProvider.GetRequiredService<ITextFileParser>();
                var peopleScoresProcessor = serviceProvider.GetRequiredService<IPeopleScoresProcessor>();
                if (args.Length < 2)
                    throw new Exception("You need to supply both parameters to continue.");
                var inputFileName = args[0];
                var outputFileName = args[1];

                ProcessTopScoringPeople(textFileParser, peopleScoresProcessor, inputFileName, outputFileName);

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured while trying to process top scorers: {ex.Message}");
                Console.ReadLine();
            }
        }

        //For simplicity, assume input and output locations are the same
        private static void ProcessTopScoringPeople(ITextFileParser textFileParser, IPeopleScoresProcessor peopleScoresProcessor, string scores, string outputFile)
        {
            var personScoreModels = textFileParser.GetScoresFromFile(scores);
            var results = peopleScoresProcessor.GetTopScoringPeople(personScoreModels);

            textFileParser.CreateTextFile(results, outputFile);

            Console.WriteLine($"Successfully Processed Top Scoring People. See file:: {outputFile}");
        }

    }
}
