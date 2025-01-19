using Microsoft.VisualStudio.TestTools.UnitTesting;
using _97NorAja_TestProject.Uppgift6;
using System;
using System.Collections.Generic;



namespace _97NorAja_TestProject.Uppgift6
{
    [TestClass]
    public class InventoryManagerTests
    {
        [TestMethod]
        public void AddItem_ShouldIncreaseQuantity_WhenItemExists()
        {
            // ARRANGE
            var manager = new InventoryManager();
            manager.AddItem("Apple", 10);

            // ACT
            manager.AddItem("Apple", 5);

            // ASSERT
            Assert.AreEqual(15, manager.GetQuantity("Apple")); // Kontrollera att kvantiteten har ökat
        }

        [TestMethod]
        public void AddItem_ShouldAddNewItem_WhenItemDoesNotExist()
        {
            // ARRANGE
            var manager = new InventoryManager();

            // ACT
            manager.AddItem("Banana", 7);

            // ASSERT
            Assert.AreEqual(7, manager.GetQuantity("Banana")); // Kontrollera att artikeln har lagts till
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddItem_ShouldThrowException_WhenQuantityIsZeroOrNegative()
        {
            // ARRANGE
            var manager = new InventoryManager();

            // ACT
            manager.AddItem("Orange", 0); // Förväntar att ett undantag kastas
        }

        [TestMethod]
        public void RemoveItem_ShouldDecreaseQuantity_WhenEnoughStockExists()
        {
            // ARRANGE
            var manager = new InventoryManager();
            manager.AddItem("Apple", 10);

            // ACT
            manager.RemoveItem("Apple", 5);

            // ASSERT
            Assert.AreEqual(5, manager.GetQuantity("Apple")); // Kontrollera att kvantiteten har minskat
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveItem_ShouldThrowException_WhenRemovingMoreThanAvailable()
        {
            // ARRANGE
            var manager = new InventoryManager();
            manager.AddItem("Apple", 5);

            // ACT
            manager.RemoveItem("Apple", 10); // Förväntar att ett undantag kastas
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveItem_ShouldThrowException_WhenItemDoesNotExist()
        {
            // ARRANGE
            var manager = new InventoryManager();

            // ACT
            manager.RemoveItem("Pear", 3); // Förväntar att ett undantag kastas
        }

        [TestMethod]
        public void GetOutOfStockItems_ShouldReturnListOfItems_WhenSomeItemsAreOutOfStock()
        {
            // ARRANGE
            var manager = new InventoryManager();
            manager.AddItem("Apple", 0);
            manager.AddItem("Banana", 5);
            manager.AddItem("Orange", 0);

            // ACT
            var outOfStockItems = manager.GetOutOfStockItems();

            // ASSERT
            CollectionAssert.AreEquivalent(new[] { "Apple", "Orange" }, outOfStockItems); // Kontrollera att rätt artiklar är slut i lagret
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetQuantity_ShouldThrowException_WhenItemDoesNotExist()
        {
            // ARRANGE
            var manager = new InventoryManager();

            // ACT
            manager.GetQuantity("Grapes"); // Förväntar att ett undantag kastas
        }

        [TestMethod]
        public void GetQuantity_ShouldReturnCorrectQuantity_WhenItemExists()
        {
            // ARRANGE
            var manager = new InventoryManager();
            manager.AddItem("Watermelon", 12);

            // ACT
            var quantity = manager.GetQuantity("Watermelon");

            // ASSERT
            Assert.AreEqual(12, quantity); // Kontrollera att rätt kvantitet returneras
        }
    }
}
