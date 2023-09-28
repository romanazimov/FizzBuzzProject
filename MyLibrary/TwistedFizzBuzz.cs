using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace MyLibrary;

public class TwistedFizzBuzz
{
    private readonly FizzBuzzConfig fizzBuzzConfig;

    public TwistedFizzBuzz() 
    {
        fizzBuzzConfig = new FizzBuzzConfig();
    }

    public void ParseInput(string input) 
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Input was empty.");
            return;
        }

        string[] inpSplit = input.Split(':');

        // Check if inpSplit has at least 2 elements
        if (inpSplit.Length < 2)
        {
            PrintInvalidInputMessage();
            return;
        }

        string value = inpSplit[1].ToString().Trim();

        if (input.StartsWith("range"))
        {
            int dashCount = DashCount(value);

            string[] rangeSplit = dashCount == 1 ? value.Split('-') : GetMinMaxFromRange(value, dashCount);

            fizzBuzzConfig.Min = int.Parse(rangeSplit[0]);
            fizzBuzzConfig.Max = int.Parse(rangeSplit[1]);
        }
        else if (input.StartsWith("set"))
        {
            string[] setVals = value.Split(',');
            foreach(var val in setVals) 
            {
                fizzBuzzConfig.RandomList.Add(int.Parse(val));
            }
        }
        else if (input.Contains("multiple") && input.Contains("word"))
        {
            string[] keyValSplit = input.Split(',');
            string multipleStr = keyValSplit[0].Split(':')[1].Trim();
            string wordStr = keyValSplit[1].Split(':')[1].Trim();

            fizzBuzzConfig.DivisorTokenPairs.Add(new KeyValuePair<int, string>(int.Parse(multipleStr), wordStr));
        }
        else
        {
            PrintInvalidInputMessage();
        }
    }

    private string[] GetMinMaxFromRange(string range, int dashCount)
    {
        int rangePos = 0;
        for (int i = 1; i < range.Length; i++) 
        {
            if (range[i - 1] == ')') 
            {
                rangePos = i;
                break;
            }
        }

        string min = range.Substring(0, rangePos).Trim('(', ')');
        string max = range.Substring(rangePos + 1).Trim('(', ')');

        int minVal = int.Parse(min);
        int maxVal = int.Parse(max);

        if (dashCount == 3 && minVal > maxVal) 
        {
            int temp = minVal;
            minVal = maxVal;
            maxVal = temp;
        }

        return new string[] { minVal.ToString(), maxVal.ToString() };
    }

    private void PrintInvalidInputMessage()
    {
        Console.WriteLine("Invalid Input.");
        Console.WriteLine("Acceptable Formats:");
        Console.WriteLine("#1 To modify default min and max (1,100): 'Range: 1-50, 1-2,000,000,000, or (-2)-(-37)'");
        Console.WriteLine("#2 To use a set of numbers instead of a range: 'Set: -5, 6, 300, 12, 15'");
        Console.WriteLine("#3 To use custom tokens and divisors: 'multiple: 7, word: Poem'");
    }

    private int DashCount(string input)
    {
        int count = 0;
        foreach(char c in input)
        {
            if (c == '-')
            {
                count++;
            }
        }
        return count;
    }






    public void Start()
    {
        var divisorTokenPairs = (IEnumerable<KeyValuePair<int, string>>)fizzBuzzConfig.DivisorTokenPairs;

        if (fizzBuzzConfig.RandomList.Any())
        {
            // Use RandomList
            if (!divisorTokenPairs.Any()) 
            {
                SetDefaultDivisorTokenPairs();
            }

            PrintFizzBuzzResults(fizzBuzzConfig.RandomList, divisorTokenPairs);
        }
        else
        {
            // Use DivisorTokenPairs
            if (!divisorTokenPairs.Any())
            {
                SetDefaultDivisorTokenPairs();
            }

            PrintFizzBuzzResults(Enumerable.Range(fizzBuzzConfig.Min, fizzBuzzConfig.Max - fizzBuzzConfig.Min + 1), divisorTokenPairs);
        }
    }

    private void SetDefaultDivisorTokenPairs() 
    {
        var kvpList = new List<KeyValuePair<int, string>>
        {
            new(3, "Fizz"),
            new(5, "Buzz")
        };

        if (kvpList.SequenceEqual(fizzBuzzConfig.DivisorTokenPairs))
        {
            fizzBuzzConfig.DivisorTokenPairs.AddRange(kvpList);
        }
        else
        {
            fizzBuzzConfig.DivisorTokenPairs.Clear();
            fizzBuzzConfig.DivisorTokenPairs.AddRange(kvpList);
        }
    }

    private void PrintFizzBuzzResults(IEnumerable<int> numbers, IEnumerable<KeyValuePair<int, string>> divisorTokenPairs)
    {
        foreach (var num in numbers)
        {
            Console.WriteLine(FizzBuzzChecker(num, divisorTokenPairs));
        }
    }

    public string FizzBuzzChecker(int pos, IEnumerable<KeyValuePair<int, string>> pairs)
    {
        StringBuilder sb = new();
        foreach(var pair in pairs)
        {
            if (pos % pair.Key == 0) {
                sb.Append(pair.Value);
            }
        }

        if (sb.ToString() == "") {
            // Console.WriteLine(pos);
            return pos.ToString();
        } else {
            return sb.ToString();
        }
    }


    public IEnumerable<KeyValuePair<int, string>> GetFizzBuzzConfigDivisorTokenpairs()
    {
        return fizzBuzzConfig.DivisorTokenPairs;
    }
}
