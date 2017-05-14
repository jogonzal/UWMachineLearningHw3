using System;
using System.IO;
using FluentAssertions;
using Homework3.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Homework3UnitTests
{
	[TestClass]
	public class ParsingUnitTests
	{
		[TestMethod]
		public void TestMethod1()
		{
			string s =
				@"/000/025 ham don 2 fw 1 35 1 jeff 2 dave 2 lynn 2 over 1 jones 2 thread 2 40 1 year 2 correlator 1 california 1 williams 2 mon 2 copyright 1 168 1 content 4 2 2 1 1 price 1 5 1 9 1 privileged 1 go 2 frank 4 19 1 harris 2 john 8 use 3 kevin 2 11 1 12 1 current 1 ferc 1 classes 1 g 2 may 2 e 1 kimberly 2 markets 1 09 2 a 3 05 1 smith 2 m 1 produced 1 w 1 new 1 u 1 shelley 2 s 4 v6 1 part 1 comments 1 2001 3 week 1 x 3 to 7 bob 4 basis 1 110 1 change 3 terms 1 mike 4 smtpsvc 1 has 2 allen 2 ken 2 any 2 michelle 2 jan 2 follow 1 be 2 index 1 text 1 electric 1 likely 1 strictly 1 and 10 that 2 urn 1 make 1 natural 1 1600 1 58 1 bill 2 steven 4 well 1 corp 3 area 1 complete 1 tom 2 corman 2 above 1 65 1 plain 1 chris 2 confidential 1 mail 1 as 3 blair 2 sheila 2 which 1 prohibited 1 michael 6 an 1 there 2 off 2 for 3 tim 2 of 6 are 3 page 1 only 1 on 3 exchange 1 kay 2 topic 1 information 1 transfer 1 or 3 msmbx01v 1 4418 1 questions 1 distribution 1 gas 3 rob 2 http 4 will 2 eric 2 disclosure 1 david 2 mime 1 some 1 scott 4 binary 1 subject 1 tnef 1 nahou 4 version 2 karen 2 craig 2 larry 4 encoding 1 thomas 2 end 1 ms 2 return 1 0500 2 attach 1 laura 2 but 1 mimeole 1 last 2 type 1 192 1 2195 1 enron 82 inc 1 january 2 power 2 miller 2 robert 2 class 1 market 2 contain 1 this 2 call 1 june 1 watson 2 one 1 was 1 steve 6 order 1 if 1 path 1 stephen 2 attachments 2 is 4 with 3 rick 2 stephanie 2 your 2 into 2 susan 2 the 12 msmbx03v 3 in 7 prices 4 discussed 1 also 1 energy 9 lisa 2 changes 1";

			File.WriteAllText("temp.txt", s);
			var example = CsvParserUtils.ParseEmailExamples("temp.txt");

			example.Should().HaveCount(1);

			example[0].IsSpam.Should().BeFalse();
			example[0].WordsInEmail.Should().HaveCount(c => c > 2);
			example[0].WordsInEmail["don"].Should().Be(2);
		}
	}
}
