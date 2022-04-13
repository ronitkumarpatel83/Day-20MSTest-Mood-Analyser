using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_20MSTest_Mood_Analyser
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Modd Analyser Program");
            MoodAnalyze analyzer = new MoodAnalyze(); //Creating a object of MoodAnalyzer class
            Console.WriteLine("\nEnter any message : ");
            string message = Console.ReadLine();
            string mood = analyzer.AnalyzeMood(message);//calling method of class with passing user message as parameter
            Console.WriteLine($"\n {mood} mood");
            Console.ReadLine();
        }
    }
}
