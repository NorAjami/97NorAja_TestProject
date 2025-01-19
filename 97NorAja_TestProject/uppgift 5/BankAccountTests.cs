using _97NorAja_TestProject.Uppgift5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _97NorAja_TestProject.Uppgift5
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Deposit_ShouldIncreaseBalance_WhenAmountIsPositive()
        {
            // ARRANGE
            var account = new BankAccount();

            // ACT
            account.Deposit(100m);

            // ASSERT
            Assert.AreEqual(100m, account.Balance);
        }

        [TestMethod]
        public void Withdraw_ShouldDecreaseBalance_WhenAmountIsValid()
        {
            // ARRANGE
            var account = new BankAccount();
            account.Deposit(200m);

            // ACT
            account.Withdraw(50m);

            // ASSERT
            Assert.AreEqual(150m, account.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Withdraw_ShouldThrowException_WhenAmountExceedsBalance()
        {
            // ARRANGE
            var account = new BankAccount();
            account.Deposit(50m);

            // ACT
            account.Withdraw(100m);

            // ASSERT handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Deposit_ShouldThrowException_WhenAmountIsNegative()
        {
            // ARRANGE
            var account = new BankAccount();

            // ACT
            account.Deposit(-50m);

            // ASSERT handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Withdraw_ShouldThrowException_WhenAmountIsNegative()
        {
            // ARRANGE
            var account = new BankAccount();

            // ACT
            account.Withdraw(-10m);

            // ASSERT handled by ExpectedException
        }
    }
}
