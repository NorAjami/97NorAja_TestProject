using _97NorAja_TestProject.calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using System;
using Xunit;

namespace _97NorAja_TestProject.Tests
{
    [TestClass]
    public class StringProcessorTests
    {
        [TestMethod]
        public void ToLowerCase_ShouldConvertStringToLowercase()
        {
            // ARRANGE
            var processor = new StringProcessor();
            string input = "HeLLo WoRLD!";
            string expected = "hello world!";

            // ACT
            string result = processor.ToLowerCase(input);

            // ASSERT
            Assert.AreEqual(expected, result);
        }
    }
}
