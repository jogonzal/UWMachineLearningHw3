using System.IO;

namespace Homework3
{
	class Program
	{
		private static string TrainingDataPath => Path.Combine(Directory.GetCurrentDirectory() + @"\..\..\..\..\netflix_data\movie_titles.txt");
		private static string TestDataPath => Path.Combine(Directory.GetCurrentDirectory() + @"\..\..\..\..\netflix_data\trainingRatings.txt");

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


		}
	}
}
