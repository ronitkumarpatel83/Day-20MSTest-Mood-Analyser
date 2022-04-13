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
            Console.WriteLine("\nEnter any message : ");
            string message = Console.ReadLine();
            MoodAnalyze analyzer = new MoodAnalyze(message); //Creating a object of MoodAnalyzer class
            string mood = analyzer.AnalyzeMood();//calling method of class with passing user message as parameter
            Console.WriteLine($"\n {mood} mood");
            Console.ReadLine();
        }
    }
}
