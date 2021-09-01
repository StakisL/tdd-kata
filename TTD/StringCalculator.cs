using System;

namespace TTD
{
    public class StringCalculator
    {
        public int Add(string number)
        {
            var numbers = number.Split(',');
            return Convert.ToInt32(numbers[0]) + Convert.ToInt32(numbers[1]);
        }
    }
}