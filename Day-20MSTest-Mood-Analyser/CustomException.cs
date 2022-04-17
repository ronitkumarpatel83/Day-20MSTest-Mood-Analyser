using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_20MSTest_Mood_Analyser
{
    public class CustomException:Exception
    {
        public enum ExceptionMood
        {
            NULL_MESSAGE,
            EMPTY_MESSAGE,
            CLASS_NOT_FOUND,
            CONSTRUCTOR_NOT_FOUND,
            METHOD_NOT_FOUND
        }
        public ExceptionMood type;
        public CustomException(ExceptionMood type,string message):base(message)
        {
            this.type = type;
        }
    }
}
