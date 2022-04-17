using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Day_20MSTest_Mood_Analyser.Reflection
{
    public class MoodAnalyzerReflector
    {
        public string InvokeMethod(string message, string methodName) // creating a method for invoking method
        {
            try
            {
                Type type = typeof(MoodAnalyze); // Getting type of mood analyzer class
                MethodInfo methodInfo = type.GetMethod(methodName); // Getting method information using reflection
                MoodAnalyzerFactory factory = new MoodAnalyzerFactory(); //Creating a object of MoodAnalyzerFactory class
                object moodAnalyzerObject = factory.CreateMoodAnalyzerParameterizedObject("Day_20MSTest_Mood_Analyser.MoodAnalyze", "MoodAnalyze", message);//Creating a parameterized object of Moodanalyzer class using reflection
                object info = methodInfo.Invoke(moodAnalyzerObject, null); //Invoking method using reflection
                return info.ToString(); //returning a mood of user
            }
            catch (NullReferenceException) //If method not found then throw exception
            {
                throw new CustomException(CustomException.ExceptionMood.METHOD_NOT_FOUND, "Method not found");
            }
        }
    }
}
