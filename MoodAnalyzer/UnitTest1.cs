using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day_20MSTest_Mood_Analyser;
using System;

namespace MoodAnalyzer
{
    [TestClass]
    public class MoodAnalysis
    {
        [TestMethod]
        public void GivenMoodSad() // TC 1.1
        {
            //arrange
            string exp = "SAD";
            string message = "I am in sad mood";
            MoodAnalyze moodAnalyzer = new MoodAnalyze();
            //act
            string act = moodAnalyzer.AnalyzeMood(message);
            ///Assert
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void GivenMoodHappy() // TC 1.2
        {
            //arrange
            string exp = "HAPPY";
            string message = "I am in happy mood";
            MoodAnalyze moodAnalyzer = new MoodAnalyze();
            //act
            string act = moodAnalyzer.AnalyzeMood(message);
            ///Assert
            Assert.AreEqual(exp, act);
        }
    }
}
