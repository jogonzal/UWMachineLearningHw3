using System;
using System.IO;
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

			var trainingEmails = CsvParserUtils.ParseEmailExamples(TrainingDataPath);
			var testEmails = CsvParserUtils.ParseEmailExamples(TestDataPath);

			var endTime = DateTime.Now;
			Console.WriteLine(endTime);
			var totalMinutes = (endTime - startTime).TotalMinutes;
			Console.WriteLine("Took {0} minutes.", totalMinutes);
			Console.WriteLine("Press any key to quit...");
			Console.ReadKey();
		}
	}
}
