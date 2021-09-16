using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using FluentAssertions;

namespace StringCalculator
{
    public class StringCalculator
    {
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
            var customDelimiter = input.Substring(2, 1);

            if (customDelimiter == "[")
            {
                var endIndex = input.IndexOf(']');
                customDelimiter = input.Substring(3, endIndex - 3);
            }
            
            var numberDigits = input.IndexOf('\n');
            var numbersString = input.Substring(numberDigits + 1);
            
            var sum = 0;
            // ReSharper disable once PossiblyMistakenUseOfParamsMethod
            var numbers = numbersString.Split(new[]{",", "\n", customDelimiter}, StringSplitOptions.None);
            
            return Sum(numbers);
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