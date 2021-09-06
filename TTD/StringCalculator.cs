using System;
using System.Text.RegularExpressions;

namespace TTD
{
    public class StringCalculator
    {
        public int Add(string inputNumbers)
        {
            if (string.IsNullOrEmpty(inputNumbers))
                return 0;

            var numbers = inputNumbers.Split(new []{',', '\n'});

            var result = 0;
            foreach (var number in numbers)
            {
                try
                {
                    result += Convert.ToInt32(number);
                }
                catch (FormatException e)
                {
                    throw new ArgumentException("Invalid format of number in string", e);
                }
            }
            
            return result;
        }

        public static string FindDelimiter(string inputString)
        {
            return Regex.Match(inputString, "(?<=^/{2})\\W").Value;
        }
    }
}