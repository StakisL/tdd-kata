using System;
using System.Diagnostics.CodeAnalysis;

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
            var result = input.Substring(2, 1);
            var numberDigits = input.IndexOf('\n');
            var numbersString = input.Substring(numberDigits + 1);
            
            var sum = 0;
            // ReSharper disable once PossiblyMistakenUseOfParamsMethod
            var numbers = numbersString.Split(',', '\n', Convert.ToChar(result));
            
            return Sum(numbers);
        }

        private int Sum(string[] numbers)
        {
            var sum = 0;
            for (int i = 0; i <numbers.Length; i++)
            {
                var number = int.Parse(numbers[i]);
                if (number < 0)
                    throw new ArgumentException("dsds");
                sum += number;
            }

            return sum;
        }
    }
}