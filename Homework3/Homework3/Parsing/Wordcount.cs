namespace Homework3.Parsing
{
	public class WordCount
	{
		public uint SpamCount { get; set; }
		public uint HamCount { get; set; }

		public WordCount()
		{
			SpamCount = 0;
			HamCount = 0;
		}

		public void Add(bool isSpam, uint count)
		{
			if (isSpam)
			{
				SpamCount+= count;
			}
			else
			{
				HamCount+= count;
			}
		}
	}
}
