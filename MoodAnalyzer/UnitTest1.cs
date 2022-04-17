using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day_20MSTest_Mood_Analyser;
using Day_20MSTest_Mood_Analyser.Reflection;
using System;

namespace MoodAnalyzer
{
    [TestClass]
    public class MoodAnalysis
    {
        MoodAnalyzerFactory moodAnalyzerFactory = new MoodAnalyzerFactory();

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
        //public void GivenMoodNull() //UC 2
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
        /// <summary>
        /// TC 4.1 Given MoodAnalyser Class Name Should Return MoodAnalyser
        /// </summary>
        [TestCategory("Reflection")]
        [TestMethod]
        public void GivenClassNameShoulReturnObject()
        {
            object expected = new MoodAnalyze();
            object actual = moodAnalyzerFactory.CreateMoodAnalyzerObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer");
            expected.Equals(actual);
        }
        /// <summary>
        /// TC 4.2 Given Class Name When Improper Should Throw MoodAnalysisException
        /// </summary>
        [TestCategory("Reflection")]
        [TestMethod]
        public void GivenInvalidClassThrowException()
        {
            try
            {
                object expected = new MoodAnalyze();
                object actual = moodAnalyzerFactory.CreateMoodAnalyzerObject("MoodAnalyzerProblem.Mood", "Mood");
            }
            catch (CustomException ex)
            {
                Assert.AreEqual("Class not found", ex.Message);
            }
        }
        /// <summary>
        /// TC 4.3 Given Constructor Name When Improper Should Throw MoodAnalysisException
        /// </summary>
        [TestCategory("Reflection")]
        [TestMethod]
        public void GivenInvalidConstructorThrowException()
        {
            try
            {
                object expected = new MoodAnalyze();
                object actual = moodAnalyzerFactory.CreateMoodAnalyzerObject("MoodAnalyzerProblem.MoodAnalyzer", "Mood");
            }
            catch (CustomException ex)
            {
                Assert.AreEqual("Constructor not found", ex.Message);
            }
        }
        /// <summary>
        /// TC 5.1 Given MoodAnalyser Class Name Should Return MoodAnalyser object with parameter
        /// </summary>
        [TestCategory("Reflection")]
        [TestMethod]
        public void GivenClassNameShoulReturnParameterizedObject()
        {
            string message = "I am in happy mood";
            object expected = new MoodAnalyze(message);
            object actual = moodAnalyzerFactory.CreateMoodAnalyzerParameterizedObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", message);
            expected.Equals(actual);
        }

        /// <summary>
        /// TC 5.2 Given Class Name When Improper Should Throw MoodAnalysisException
        /// </summary>
        [TestCategory("Reflection")]
        [TestMethod]
        public void GivenInvalidClassNameWithMessageThrowException()
        {
            try
            {
                string message = "I am in happy mood";
                object expected = new MoodAnalyze(message);
                object actual = moodAnalyzerFactory.CreateMoodAnalyzerParameterizedObject("MoodAnalyzerProblem.Mood", "Mood", message);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual("Class not found", ex.Message);
            }
        }
        /// <summary>
        /// TC 5.3 Given Constructor Name When Improper Should Throw MoodAnalysisException
        /// </summary>
        [TestCategory("Reflection")]
        [TestMethod]
        public void GivenInvalidConstructorWithMessageThrowException()
        {
            try
            {
                string message = "I am in happy mood";
                object expected = new MoodAnalyze(message);
                object actual = moodAnalyzerFactory.CreateMoodAnalyzerParameterizedObject("MoodAnalyzerProblem.MoodAnalyzer", "Mood", message);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual("Constructor not found", ex.Message);
            }
        }
        /// <summary>
        /// TC 6.1 Given Happy Message Using Reflection When Proper Should Return HAPPY Mood by invoking a method
        /// </summary>
        [TestCategory("Reflection")]
        [TestMethod]
        public void GivenMethodNameWithMessageReturnMood()
        {
            string message = "I am in happy mood";
            string expected = "HAPPY";
            string actual = "";
            try
            {
                MoodAnalyzerReflector moodAnalyzerReflector = new MoodAnalyzerReflector();
                actual = moodAnalyzerReflector.InvokeMethod(message, "AnalyzeMood");
            }
            catch (CustomException ex)
            {
                Assert.AreEqual("Method not found", ex.Message);
            }
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// TC 6.2 Given Happy Message When Improper Method Should Throw MoodAnalysisException
        /// </summary>
        [TestCategory("Reflection")]
        [TestMethod]
        public void GivenInvalidMethodNameWithMessageThrowException()
        {
            string message = "I am in happy mood";
            string expected = "HAPPY";
            string actual = "";
            try
            {
                MoodAnalyzerReflector moodAnalyzerReflector = new MoodAnalyzerReflector();
                actual = moodAnalyzerReflector.InvokeMethod(message, "Mood");
                Assert.AreEqual(expected, actual);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual("Method not found", ex.Message);
            }
        }
        /// <summary>
        /// TC 7.1 Set Happy Message with Reflector Should Return HAPPY
        /// </summary>
        [TestCategory("Reflection")]
        [TestMethod]
        public void GivenFieldNameAndMessageReturnsMood()
        {
            string userMessage = "I am in happy mood";
            string fieldName = "message";
            string expected = "HAPPY";
            string actual = "";

            MoodAnalyzerReflector moodAnalyzerReflector = new MoodAnalyzerReflector();
            actual = moodAnalyzerReflector.SetField(userMessage, fieldName);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// TC 7.2 Set Field When Improper Should Throw Exception with No Such Field
        /// </summary>
        [TestCategory("Reflection")]
        [TestMethod]
        public void GivenInvalidFieldNameThrowException()
        {
            string userMessage = "I am in happy mood";
            string fieldName = "mood";
            string expected = "HAPPY";
            string actual = "";
            try
            {
                MoodAnalyzerReflector moodAnalyzerReflector = new MoodAnalyzerReflector();
                actual = moodAnalyzerReflector.SetField(userMessage, fieldName);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual("Field name not found", ex.Message);
            }
        }
        /// <summary>
        /// TC 7.3 Setting Null Message with Reflector Should Throw Exception
        /// </summary>
        [TestCategory("Reflection")]
        [TestMethod]
        public void GivenNullMessageThrowException()
        {
            string userMessage = null;
            string fieldName = "message";
            string actual = "";
            try
            {
                MoodAnalyzerReflector moodAnalyzerReflector = new MoodAnalyzerReflector();
                actual = moodAnalyzerReflector.SetField(userMessage, fieldName);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual("Message should not be null", ex.Message);
            }
        }
    }
}
