using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using FluentAssertions;

namespace StringCalculator
{
    public class StringCalculator
    {
        const string StartOfDelimiterTag = "[";
        const string EndOfDelimiterTag = "]";

        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            return input.StartsWith("//") ? AddWithCustomDelimiter(input) : AddWithoutDelimiter(input);
        }

        private int AddWithoutDelimiter(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            var sum = 0;
            // ReSharper disable once PossiblyMistakenUseOfParamsMethod
            var numbers = input.Split(',', '\n');

            return Sum(numbers);
        }

        private int AddWithCustomDelimiter(string input)
        {
            var delimiters = FindCustomDelimiters(input);

            var numberDigits = input.IndexOf('\n');
            var numbersString = input.Substring(numberDigits + 1);
            
            var defaultDelimiters = new[]{",", "\n"};
            delimiters.AddRange(defaultDelimiters);
            
            var numbers = numbersString.Split(delimiters.ToArray(), StringSplitOptions.None);
            
            return Sum(numbers);
        }

        private List<string> FindCustomDelimiters(string input)
        {
            var delimiter = FindSingleCharacterDelimiter(input, out var customDelimiter);
            if (delimiter != null)
            {
                return delimiter;
            }

            var delimiters = FindMultiCharacterDelimiters(input);

            if (delimiters.Count > 0)
            {
                return delimiters;
            }
            
            int startIndex = 3;
            var endIndex = input.IndexOf(EndOfDelimiterTag, StringComparison.Ordinal);

            if (endIndex == -1)
            {
                return new List<string>{customDelimiter};
            }
            
            return new List<string>{input.Substring(startIndex, endIndex - startIndex)};
        }

        private static List<string> FindSingleCharacterDelimiter(string input, out string customDelimiter)
        {
            customDelimiter = input.Substring(2, 1);

            if (customDelimiter != StartOfDelimiterTag)
            {
                return new List<string> {customDelimiter};
            }

            return null;
        }

        private static List<string> FindMultiCharacterDelimiters(string input)
        {
            var delimiters = new List<string>();
            var matches = Regex.Matches(input, "\\[(.*?)\\]");
            foreach (var match in matches)
            {
                if (match is not Match currentMatch)
                    continue;

                delimiters.Add(currentMatch.Groups[1].Value);
            }

            return delimiters;
        }

        private int Sum(string[] numbers)
        {
            var sum = 0;
            var negatives = new List<int>();
            for (int i = 0; i <numbers.Length; i++)
            {
                var number = int.Parse(numbers[i]);
                if (number < 0)
                {
                    negatives.Add(number);
                }

                if (number <= 1000)
                {
                    sum += number;
                }
            }

            if (negatives.Count > 0)
            {
                throw new ArgumentException($"Negatives not allowed: {String.Join(',', negatives)}");
            }
            
            return sum;
        }
    }
}