using System;
using System.Collections.Generic;
using System.IO;

namespace Homework3.Parsing
{
	public static class CsvParserUtils
	{
		public static List<EmailExample> ParseEmailExamples(string path)
		{
			var lines = File.ReadAllLines(path);
			List<EmailExample> emailExamples = new List<EmailExample>(lines.Length);
			foreach (var line in lines)
			{
				string[] delimitedBySpace = line.Split(new [] { ' ' });

				if (line.Length < 2)
				{
					throw new InvalidOperationException();
				}

				string emailId = delimitedBySpace[0];
				bool isSpam = delimitedBySpace[1].Equals("spam", StringComparison.OrdinalIgnoreCase);
				var emailExample = new EmailExample(emailId, isSpam, delimitedBySpace.Length / 2 - 1);

				for (int i = 2; i < delimitedBySpace.Length; i += 2)
				{
					string word = delimitedBySpace[i];
					uint count = uint.Parse(delimitedBySpace[i + 1]);

					emailExample.WordsInEmail.Add(word, count);
				}

				emailExamples.Add(emailExample);
			}

			return emailExamples;
		}
	}
}
