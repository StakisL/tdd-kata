using System;

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
            for (int i = 0; i <numbers.Length; i++)
            {
                sum += int.Parse(numbers[i]);
            }

            return sum;
        }

        private int AddWithCustomDelimiter(string input)
        {
            var result = input.Substring(2, 1);
            var numberDigits = input.IndexOf('\n');
            var numbersString = input.Substring(numberDigits + 1);
            
            var sum = 0;
            // ReSharper disable once PossiblyMistakenUseOfParamsMethod
            var numbers = numbersString.Split(',', '\n', Convert.ToChar(result));
            for (int i = 0; i <numbers.Length; i++)
            {
                sum += int.Parse(numbers[i]);
            }

            return sum;
        }
    }
}