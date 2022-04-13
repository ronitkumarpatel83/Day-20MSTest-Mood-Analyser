using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day_20MSTest_Mood_Analyser;
using System;

namespace MoodAnalyzer
{
    [TestClass]
    public class MoodAnalysis
    {
        [TestMethod]
        public void GivenMoodSad() //Refactor TC 1.1
        {
            //arrange
            string exp = "SAD";
            string message = "I am in sad mood";
            MoodAnalyze moodAnalyzer = new MoodAnalyze(message);
            //act
            string act = moodAnalyzer.AnalyzeMood();
            ///Assert
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        public void GivenMoodHappy() //Refactor TC 1.2
        {
            //arrange
            string exp = "HAPPY";
            string message = "I am in happy mood";
            MoodAnalyze moodAnalyzer = new MoodAnalyze(message);
            //act
            string act = moodAnalyzer.AnalyzeMood();
            ///Assert
            Assert.AreEqual(exp, act);

        }
        //[TestMethod]
        //public void GivenMoodNull() //Refactor TC 1.2
        //{
        //    //arrange
        //    string exp = "HAPPY";
        //    string message = null;
        //    MoodAnalyze moodAnalyzer = new MoodAnalyze(message);
        //    //act
        //    string act = moodAnalyzer.AnalyzeMood();
        //    ///Assert
        //    Assert.AreEqual(exp, act);
        //}
        [TestMethod]
        public void GivenMoodNull() //UC 3 and TC 3.1
        {
            try
            {
                //arrange
                string message = null;
                MoodAnalyze moodAnalyzer = new MoodAnalyze(message);
                //act
                string act = moodAnalyzer.AnalyzeMood();
            }
            catch (CustomException ex)
            {
                ///Assert
                Assert.AreEqual("Message should not be Null", ex.Message);
            }
        }
        [TestMethod]
        public void GivenMoodEmpty() //UC 3 and TC 3.2
        {
            try
            {
                //arrange
                string message = "";
                MoodAnalyze moodAnalyzer = new MoodAnalyze(message);
                //act
                string act = moodAnalyzer.AnalyzeMood();
            }
            catch (CustomException ex)
            {
                ///Assert
                Assert.AreEqual("Message should not be Empty", ex.Message);
            }
        }
    }
}
