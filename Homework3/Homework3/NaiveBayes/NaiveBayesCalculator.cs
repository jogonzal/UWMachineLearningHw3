using System.Collections.Generic;
using System.Linq;

using Homework3.Parsing;

namespace Homework3.NaiveBayes
{
	public static class NaiveBayesCalculator
	{
		public static double ObtainProbabilityOfSpam(IDictionary<string, uint> testWordsInEmail, Dictionary<string, WordCount> trainingEmails)
		{
			double probabilitySpam = 0;
			var totalWords = testWordsInEmail.Sum(w => w.Value);
			foreach (var u in testWordsInEmail)
			{
				double wordWeight = 1.0 * u.Value / totalWords;

				// Count all the times this word was spam
				WordCount wordCount;
				if (!trainingEmails.TryGetValue(u.Key, out wordCount))
				{
					// If we've never sen the word, then it's 50/50
					wordCount = new WordCount();
					wordCount.Add(false, 1);
					wordCount.Add(true, 1);
				}

				double probabilityOfWordBeingSpam = 1.0 * wordCount.SpamCount/(wordCount.SpamCount + wordCount.HamCount);

				probabilitySpam += wordWeight*probabilityOfWordBeingSpam;
			}

			return probabilitySpam;
		}
	}
}
