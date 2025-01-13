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

        [Fact]
        public void AreEqual_ShouldReturnTrue_ForEqualStrings()
        {
            // ARRANGE
            var processor = new StringProcessor();
            var input1 = "Hello@123";
            var input2 = "hello123";

            // ACT
            var result = processor.AreEqual(input1, input2);

            // ASSERT
            Assert.True(result);
        }

        [Fact]
        public void AreEqual_ShouldReturnFalse_ForDifferentStrings() // denna testar om två strängar är olika
        {
            // ARRANGE
            var processor = new StringProcessor();
            var input1 = "Hello123";
            var input2 = "World123";

            // ACT
            var result = processor.AreEqual(input1, input2);

            // ASSERT
            Assert.False(result);
        }

        [Fact]
        public void AreEqual_ShouldReturnTrue_ForStringsWithDifferentCases() // när två strängar är lika men olika i storlek på bokstäver (lowercase/uppercase) ska fortfarande bli true
        {
            var processor = new StringProcessor();
            var result = processor.AreEqual("Hello", "hello");
            Assert.True(result);
        }

        [Fact]
        public void AreEqual_ShouldReturnFalse_ForStringsWithSameCharactersInDifferentOrder() // när två strängar har samma bokstäver men olika ordning ska bli false
        {
            var processor = new StringProcessor();
            var result = processor.AreEqual("abc", "cba");
            Assert.False(result);
        }

        [Fact]
        public void ToLowerCase_ShouldReturnEmptyString_WhenInputIsEmpty() // om input är en tom sträng ska returnera en tom sträng
        {
            var processor = new StringProcessor();
            var result = processor.ToLowerCase("");
            Assert.Equal("", result);
        }

        [Fact]
        public void Sanitize_ShouldReturnEmptyString_WhenInputContainsOnlySpecialCharacters() // om input endast innehåller specialtecken ska returnera en tom sträng för sanitize metoden
        {
            var processor = new StringProcessor();
            var result = processor.Sanitize("!!!@@@###");
            Assert.Equal("", result);
        }


    }
}
