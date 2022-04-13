using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day_20MSTest_Mood_Analyser;
using System;

namespace MoodAnalyzer
{
    [TestClass]
    public class MoodAnalysis
    {
        [TestMethod]
        public void GivenMood() // UC 1
        {
            //arrange
            MoodAnalyze moodAnalyzer = new MoodAnalyze();
            string exp = "SAD";
            string message = "I am in sad mood";
            //act
            string act = moodAnalyzer.AnalyzeMood(message);
            ///Assert
            Assert.AreEqual(exp, act);
            
        }
    }
}
