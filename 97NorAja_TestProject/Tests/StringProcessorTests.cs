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

        // TODO: NULL INPUT TEST

        [Fact]
        public void ToLowerCase_ShouldReturnNull_WhenInputIsNull()
        {
            // ARRANGE
            var processor = new StringProcessor();

            // ACT
            string result = processor.ToLowerCase(null);

            // ASSERT
            Assert.Null(result);
        }


        [Fact]
        public void Sanitize_ShouldRemoveSpecialCharacters()
        {
            // ARRANGE
            var processor = new StringProcessor();
            string input = "Ja@g ee hu#ngri%g 123 MA@T!";
            // ACT
            string result = processor.Sanitize(input);
            // ASSERT
            Assert.Equal("Jag ee hungrig 123 MAT", result);
        }

        [Fact]
        public void Sanitize_ShouldReturnNull_WhenInputIsNull()
        {
            // ARRANGE
            var processor = new StringProcessor();

            // ACT
            var result = processor.Sanitize(null);

            // ASSERT
            Assert.Null(result);
        }
    }
}
