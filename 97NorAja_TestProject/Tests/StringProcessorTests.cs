using _97NorAja_TestProject.calculator;
using static Xunit.Assert;
using System;
using Xunit;

namespace _97NorAja_TestProject.Tests
{
    
    public class StringProcessorTests
    {
        [Fact]
        public void ToLowerCase_ShouldConvertStringToLowercase() 
        {
            // ARRANGE
            var processor = new StringProcessor();
            string input = "JaG Är HunGriG!";
            string expected = "jag är hungrig!";

            // ACT
            string result = processor.ToLowerCase(input); // förvämtat resultat är "jag är hungrig!"

            // ASSERT
            Assert.Equal(expected, result); // jämför förväntat resultat med faktiskt resultat
        }

        [Fact]

    }
}
