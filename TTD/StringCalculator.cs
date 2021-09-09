using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TTD
{
    public class StringCalculator
    {
        public int Add(string inputNumbers)
        {
            if (string.IsNullOrEmpty(inputNumbers))
                return 0;

            var delimiter = FindDelimiter(inputNumbers);

            var numbersString = FindNumbers(inputNumbers);
            var numbers = numbersString.Split(new []{Convert.ToChar(delimiter), '\n'});

            var result = 0;
            var negatives = new List<string>();
            foreach (var number in numbers)
            {
                try
                {
                    int coercedNumber = Convert.ToInt32(number);
                    if (coercedNumber < 0)
                    {
                        negatives.Add(number);
                    }
                    
                    result += coercedNumber;
                }
                catch (FormatException e)
                {
                    var errorMessage = string.Join(',', negatives);
                    throw new ArgumentException($"negative not allowed: {errorMessage}", e);
                }
            }
            
            return result;
        }

        public static string FindDelimiter(string inputString)
        {
            var delimiter = Regex.Match(inputString, "(?<=^/{2})\\W").Value;
            return String.IsNullOrEmpty(delimiter) ? "," : delimiter;
        }

        public static string FindNumbers(string inputString)
        {
            if (!inputString.StartsWith("//")) 
                return inputString;
            
            var result = Regex.Match(inputString, "\\\n(.*)");

            if (result.Groups.Count == 1 && result.ToString() == inputString)
            {
                return inputString;
            }

            return result.Groups[1].Value;
        }
    }
}