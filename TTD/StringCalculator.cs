using System;

namespace TTD
{
    public class StringCalculator
    {
        public int Add(string inputNumbers)
        {
            if (string.IsNullOrEmpty(inputNumbers))
                return 0;
            
            var numbers = inputNumbers.Split(',');

            var result = 0;
            foreach (var number in numbers)
            {
                result += Convert.ToInt32(number);
            }
            
            return result;
        }
    }
}