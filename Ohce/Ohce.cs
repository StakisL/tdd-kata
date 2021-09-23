using System;
using System.Collections.Generic;
using System.Linq;

namespace Ohce
{
    public class Ohce
    {
        private readonly IDateTimeService _dateTimeService;

        public Ohce(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }

        public string Start(string name) => _dateTimeService.GetCurrentDateTime() switch
        {
            {Hour: > 20 or < 6} => $"¡Buenas noches {name}!",
            {Hour: > 6 and < 12} => $"¡Buenas dias {name}!",
            {Hour: > 12 and < 20} => $"¡Buenas tardes {name}!",
            _ => throw new ArgumentException()
        };

        public string ReverseWord(string word)
        {
            string result = "";

            if (word.Equals("Stop!"))
                return "Adios Pedro";

            IEnumerable<char> reverseCharacters = word.Reverse();
            var reversedWord = new string(reverseCharacters.ToArray());;
            result = reversedWord;
            
            if (IsPalindrome(word))
            {
                return result + Environment.NewLine + "¡Bonita palabra!";
            }

            return result;
        }
        
        public static bool IsPalindrome(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] != word[word.Length-i-1])
                    return false;
            }

            return true;
        }
    }

    public interface IDateTimeService
    {
        DateTime GetCurrentDateTime();
    }
}