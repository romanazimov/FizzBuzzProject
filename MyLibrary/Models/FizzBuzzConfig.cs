using System.Collections.Generic;

namespace MyLibrary
{
    public class FizzBuzzConfig
    {
        public List<int> RandomList { get; set; } = new();
        // public int Min { get; set; } = -20;
        public int Min { get; set; }
        public int Max { get; set; }
        public List<KeyValuePair<int, string>> DivisorTokenPairs { get; set; } = new();
        // public List<KeyValuePair<int, string>> DivisorTokenPairs { get; set; } = new()
        // {
        //     new KeyValuePair<int, string>(3, "Fizz"),
        //     new KeyValuePair<int, string>(5, "Buzz")
        // };

        public FizzBuzzConfig()
        {
            DefaultConfig();
        }

        private void DefaultConfig() 
        {
            Min = 1;
            Max = 100;
            // DivisorTokenPairs = new() 
            // {
            //     new KeyValuePair<int, string>(3, "Fizz"),
            //     new KeyValuePair<int, string>(5, "Buzz")
            // };
        }
    }
}



// using System;
// using System.Collections.Specialized;
// namespace TwistedFizzBuzz.Models
// {
// 	public class FizzBuzzConfig
// 	{
// 		public List<int> RandomList { get; set; }
// 		public int Min { get; set; }
// 		public int Max { get; set; }
//         public List<KeyValuePair<int, string>> DivisorTokenPairs { get; set; }
// 		//public OrderedDictionary DivisorTokenPairs { get; set; }

//         public FizzBuzzConfig(string input)
// 		{
// 			RandomList = new();
// 			Min = 1;
// 			Max = 100;
// 			DivisorTokenPairs = new()
// 			{
// 				new KeyValuePair<int, string>(3, "Fizz" ),
//                 new KeyValuePair<int, string>(5, "Buzz" )
//             };

// 			ParseInput(input);
//         }

//         private void ParseInput(string input)
// 		{
// 			// "Range: 1-50"
// 			if (input.StartsWith("Range"))
// 			{
// 				try
// 				{
// 					string[] contents = input.Split(' ');
// 					if (contents.Length == 2)
// 					{
// 						string range = contents[1];
// 						string[] rangeVals = range.Split('-');
// 						if (rangeVals.Length == 2)
// 						{
// 							Min = int.Parse(rangeVals[0]);
// 							Max = int.Parse(rangeVals[1]);
// 						}
// 					}
// 				}
// 				catch (Exception)
// 				{
//                     Console.WriteLine("Invalid format.");
// 					return;
// 				}
// 			}
// 			// "Set: -5, 6, 300, 12, 15"
// 			else if (input.StartsWith("Range"))
// 			{
//                 Console.WriteLine("Range");
// 				// Split
// 				// Trim
// 				// Check if Numerical
// 				// If it is, RandomList.Add()
// 			}
//             // "Divisors: 7, 17, 3; Tokens: Poem, Writer, College"
//             else if (input.StartsWith("Divisors"))
//             {
//                 Console.WriteLine("Divisors");
// 				// Split on ';'
// 				// Check Divisors

// 				// Check Tokens
//             }
// 			else
// 			{
// 				Console.WriteLine("Invalid Format.");
// 			}
//         }
// 	}
// }

