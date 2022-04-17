using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_20MSTest_Mood_Analyser.Reflection
{
    public class MoodAnalyzerFactory
    {
        public object CreateMoodAnalyzerObject(string className, string constructor)
        {
            try
            {
                if (className == null || constructor == null) // If any field null then throw exception
                {
                    throw new CustomException(CustomException.ExceptionMood.NULL_MESSAGE, "Class name or constructor name should not be null");
                }
                string pattern = "." + constructor + "$"; // regex for class
                Match result = Regex.Match(className, pattern); // Checking that Class name and constructor name is equal or not             

                if (result.Success) // If class name matched with constructor name then 
                {
                    try
                    {
                        Assembly assembly = Assembly.GetExecutingAssembly();
                        Type moodAnalyzerType = assembly.GetType(className); // Get the class name type from assembly
                        return Activator.CreateInstance(moodAnalyzerType);
                    }
                    catch (ArgumentNullException) //If class not found in assembly then throw exception
                    {
                        throw new CustomException(CustomException.ExceptionMood.CLASS_NOT_FOUND, "Class not found");
                    }
                }
                else // Constructor name not matched with class name then throw exception like constructor not found
                {
                    throw new CustomException(CustomException.ExceptionMood.CONSTRUCTOR_NOT_FOUND, "Constructor not found");
                }
            }
            catch (CustomException e)
            {
                return e.Message;
            }
        }
    }
}
