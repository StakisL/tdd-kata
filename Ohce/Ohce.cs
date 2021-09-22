using System;

namespace Ohce
{
    public class Ohce
    {
        public Ohce(IDateTimeService dateTimeService)
        {
            
        }
        
        public string Start(string name)
        {
            return $"¡Buenas noches {name}!";
        }
    }

    public interface IDateTimeService
    {
        DateTime GetCurrentDateTime();
    }
}