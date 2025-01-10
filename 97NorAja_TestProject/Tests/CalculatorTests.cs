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
