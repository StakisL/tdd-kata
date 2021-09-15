namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string input)
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
    }
}