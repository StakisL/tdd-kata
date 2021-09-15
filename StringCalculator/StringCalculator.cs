namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            var sum = 0;
            var numbers = input.Split(',');
            for (int i = 0; i <numbers.Length; i++)
            {
                sum += int.Parse(numbers[i]);
            }

            return sum;
        }
    }
}