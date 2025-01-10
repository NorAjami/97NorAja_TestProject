using System;
using System.Linq;
using Xunit;
using static _97NorAja_TestProject.Calculator;

namespace _97NorAja_TestProject
{
    public class UnitTest1
    {
        [Fact]
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
    }
}
