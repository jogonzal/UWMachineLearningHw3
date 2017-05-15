using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Homework3.NaiveBayes;
using Homework3.Parsing;

namespace Homework3
{
	class Program
	{
		private static string TrainingDataPath => Path.Combine(Directory.GetCurrentDirectory() + @"\..\..\..\..\data\train");
		private static string TestDataPath => Path.Combine(Directory.GetCurrentDirectory() + @"\..\..\..\..\data\test");

		static void Main(string[] args)
		{
			string errorMessage = "";
			if (!File.Exists(TrainingDataPath))
			{
				errorMessage += $"Failed to find file ${TrainingDataPath} - please update variable ${nameof(TrainingDataPath)} or create that file.\n";
			}
			if (!File.Exists(TestDataPath))
			{
				errorMessage += $"Failed to find file ${TestDataPath} - please update variable ${nameof(TestDataPath)} or create that file.\n";
			}
			if (errorMessage != "")
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Not all files available - not running!");
				Console.WriteLine(errorMessage);
				Console.ResetColor();
				Console.WriteLine("Press any key to continue...");
				Console.ReadKey();
				return;
			}

			var startTime = DateTime.Now;
			Console.WriteLine(startTime);

			Console.WriteLine("Parsing...");
			List<EmailExample> trainingEmails;
			Dictionary<string, WordCount> trainingCounts = CsvParserUtils.ParseEmailExamples(TrainingDataPath, out trainingEmails);
			List<EmailExample> testEmails;
			CsvParserUtils.ParseEmailExamples(TestDataPath, out testEmails);

			double probabilitySpam = 1.0 * trainingEmails.Count(t => t.IsSpam) / trainingEmails.Count;

			Console.WriteLine("Making predictions...");
			uint hits = 0, misses = 0;
			uint falsePositives = 0, falseNegatives = 0;
			foreach (var emailExample in testEmails)
			{
				//double probabilityOfSpam = NaiveBayesCalculator.ObtainProbabilityOfSpam(emailExample.WordsInEmail, trainingCounts, probabilitySpam);
				//bool isSpamPrediction = probabilityOfSpam > 0.5;

				var probabilityOfSpam = NaiveBayesCalculator.ObtainProbabilityOfSpam(emailExample.WordsInEmail, trainingCounts, probabilitySpam, trainingCounts.Count);
				bool isSpamPrediction = probabilityOfSpam.Item1 > probabilityOfSpam.Item2;
				if (isSpamPrediction && emailExample.IsSpam)
				{
					hits++;
				}
				else if (!isSpamPrediction && !emailExample.IsSpam)
				{
					hits++;
				}
				else if (isSpamPrediction && !emailExample.IsSpam)
				{
					misses++;
					falsePositives++;
				}
				else if (!isSpamPrediction && emailExample.IsSpam)
				{
					misses++;
					falseNegatives++;
				}
				else
				{
					throw new InvalidOperationException();
				}
			}

			Console.WriteLine("Score: {0}%. Hits: {1}, Misses: {2}", 100.0 * hits / (misses + hits), hits, misses);
			Console.WriteLine("FalsePositives: {0}. FalseNegatives: {1}", falsePositives, falseNegatives);

			var endTime = DateTime.Now;
			Console.WriteLine(endTime);
			var totalMinutes = (endTime - startTime).TotalMinutes;
			Console.WriteLine("Took {0} minutes.", totalMinutes);
			Console.WriteLine("Press any key to quit...");
			Console.ReadKey();
		}
	}
}
