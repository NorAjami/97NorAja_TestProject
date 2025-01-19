using System;
using System.Linq;
using Xunit;
using static _97NorAja_TestProject.Calculator;

namespace _97NorAja_TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Add_ShouldReturnCorrectSum_WhenAddingNegativeAndPositiveFloats()
        {
            // ARRANGE
            var calculator = new Calculator();
            float a = -5.5f;
            float b = 10.5f;

            // ACT
            float result = calculator.Add(a, b);

            // ASSERT
            Assert.Equal(5.0f, result);
        }

        [Fact]
        public void Subtract_ShouldReturnCorrectDifference_WhenSubtractingNegativeAndPositiveFloats()
        {
            // ARRANGE
            var calculator = new Calculator();
            float a = -5.5f;
            float b = 10.5f;
            // ACT
            float result = calculator.Subtract(a, b); // -5.5 - 10.5 = -16.0
            // ASSERT
            Assert.Equal(-16.0f, result);
        }

        [Fact]
        public void Multiply_ShouldReturnCorrectProduct_WhenMultiplyingNegativeAndPositiveFloats()
        {
            // ARRANGE
            var calculator = new Calculator();
            float a = -5.5f;
            float b = 10.5f;
            // ACT
            float result = calculator.Multiply(a, b); // -5.5 * 10.5 = -57.75
            // ASSERT
            Assert.Equal(-57.75f, result);
        }

       
        [Fact]
        public void Add_ShouldReturnCorrectSum_WhenAddingTwoNegativeFloats()
        {
            // ARRANGE
            var calculator = new Calculator();
            float a = -5.5f;
            float b = -10.5f;
            // ACT
            float result = calculator.Add(a, b); // -5.5 + -10.5 = -16.0
            // ASSERT
            Assert.Equal(-16.0f, result);
        }

        [Fact]
        public void Divide_ByZero_ShouldThrowDivideByZeroException()
        {
            // ARRANGE
            var calculator = new Calculator();
            float a = 10.0f;
            float b = 0.0f;

            // ACT & ASSERT
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(a, b)); // 10 / 0 = DivideByZeroException
        }

        [Fact]
        public void Divide_ShouldReturnZero_WhenNumeratorIsZero()
        {
            // ARRANGE
            var calculator = new Calculator();
            float a = 0.0f;
            float b = 5.0f;

            // ACT
            float result = calculator.Divide(a, b);

            // ASSERT
            Assert.Equal(0.0f, result);
        }

        [Fact]
        public void Divide_ShouldHandleSmallFloats()
        {
            // ARRANGE
            var calculator = new Calculator();
            float a = 0.0001f;
            float b = 0.0002f;

            // ACT
            float result = calculator.Divide(a, b);

            // ASSERT
            Assert.Equal(0.5f, result);
        }

        [Fact]
        public void Divide_ShouldHandleLargeFloats()
        {
            // ARRANGE
            var calculator = new Calculator();
            float a = 1000000000.0f;
            float b = 1000000000.0f;
            // ACT
            float result = calculator.Divide(a, b);
            // ASSERT
            Assert.Equal(1.0f, result);
        }

        [Fact]
        public void Add_ShouldHandleExtremeValues() // MaxValue + MaxValue = Infinity
        {
            // ARRANGE
            var calculator = new Calculator();
            float a = float.MaxValue;
            float b = float.MaxValue;

            // ACT
            float result = calculator.Add(a, b);

            // ASSERT
            Assert.True(float.IsInfinity(result), "Resultatet av två MaxValue bör bli oändlighet (Infinity).");

        }

        [Fact]
        public void Multiply_ShouldResultInInfinity_WhenMultiplyingLargeNumbers()
        {
            // ARRANGE
            var calculator = new Calculator();
            float a = 1e38f; // 1 * 10^38.   Ett tal nära float.MaxValue
            float b = 10.0f; // Multiplicera med ett stort tal

            // ACT
            float result = calculator.Multiply(a, b);

            // ASSERT
            Assert.True(float.IsInfinity(result), "Multiplikation av mycket stora tal bör resultera i oändlighet (Infinity)."); 
        }























        //råkade köra int istället för float men körde nya tester efteråt.
        /* [Fact]
        public void Add_ShouldReturnSumOfTwoNumbers()
        {
            // Arrange
            var calculator = new Calculator();
            int a = 10;
            int b = 20;
            // Act
            int result = calculator.Add(a, b); // 10 + 20 = 30
            // Assert
            Assert.Equal(30, result); // Expected result is 30  
        }


        [Fact]
        public void Subtract_ShouldReturnDifferenceOfTwoNumbers()
        {
            // Arrange
            var calculator = new Calculator();
            int a = 20;
            int b = 10;
            // Act
            int result = calculator.Subtract(a, b); // 20 - 10 = 10
            // Assert
            Assert.Equal(10, result); // Expected result is 10  
        }

        [Fact]
        public void Multiply_ShouldReturnProductOfTwoNumbers()
        {
            // Arrange
            var calculator = new Calculator();
            int a = 5;
            int b = 5;
            // Act
            int result = calculator.Multiply(a, b); 
            // Assert
            Assert.Equal(25, result);   
        }

        [Fact]
        public void Divide_ShouldReturnQuotientOfTwoNumbers()
        {
            // ARRANGE
            var calculator = new Calculator();
            int a = 20;
            int b = 4;

            // ACT
            int result = calculator.Divide(a, b);

            // ASSERT
            Assert.Equal(5, result);
        }
        */
    }
}
