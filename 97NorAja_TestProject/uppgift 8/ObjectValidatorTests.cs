using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _97NorAja_TestProject.uppgift_8
{
    [TestClass]
    public class ObjectValidatorTests
    {
        [TestMethod]
        public void IsNull_ShouldReturnTrue_WhenObjectIsNull()
        {
            // ARRANGE
            var validator = new ObjectValidator();

            // ACT
            var result = validator.IsNull(null);

            // ASSERT
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNull_ShouldReturnFalse_WhenObjectIsNotNull()
        {
            // ARRANGE
            var validator = new ObjectValidator();

            // ACT
            var result = validator.IsNull(new object());

            // ASSERT
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetNullProperties_ShouldReturnListOfNullProperties()
        {
            // ARRANGE
            var validator = new ObjectValidator();
            var testObject = new
            {
                Name = "Test",
                Age = (int?)null,
                Address = (string)null
            };

            // ACT
            var result = validator.GetNullProperties(testObject);

            // ASSERT
            CollectionAssert.AreEqual(new List<string> { "Age", "Address" }, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetNullProperties_ShouldThrowArgumentNullException_WhenObjectIsNull()
        {
            // ARRANGE
            var validator = new ObjectValidator();

            // ACT
            validator.GetNullProperties(null);

            // ASSERT: Hanteras av ExpectedException
        }

        [TestMethod]
        public void GetNullProperties_ShouldReturnEmptyList_WhenNoPropertiesAreNull()
        {
            // ARRANGE
            var validator = new ObjectValidator();
            var testObject = new
            {
                Name = "Nor",
                Age = 27,
                Address = "123 Street"
            };

            // ACT
            var result = validator.GetNullProperties(testObject);

            // ASSERT
            Assert.AreEqual(0, result.Count);
        }
    }
}
