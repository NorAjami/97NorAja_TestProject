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

        //fler test krachfall
        //vill verifiera att ett nytt konto alltid startar med ett saldo på 0.
        [TestMethod]
        public void Balance_ShouldBeZero_WhenAccountIsCreated()
        {
            // ARRANGE
            var account = new BankAccount();

            // ACT
            var balance = account.Balance;

            // ASSERT
            Assert.AreEqual(0m, balance, "The balance should be zero when a new account is created.");
        }

        //vill verifiera att det inte går att sätta in ett negativt alt 0kr belopp på kontot.
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Deposit_ShouldThrowException_WhenAmountIsZero() 
        {
            // ARRANGE
            var account = new BankAccount();

            // ACT
            account.Deposit(0m);

            // ASSERT
            // Förväntat undantag hanteras av [ExpectedException]
        }

        
        [TestMethod]
        public void Balance_ShouldBeCorrect_AfterMultipleDepositsAndWithdrawals() //testar flera transaktioner i rad och verifierar att saldot är korrekt
        {
            // ARRANGE
            var account = new BankAccount();

            // ACT
            account.Deposit(100m); // Nytt saldo: 100
            account.Deposit(50m);  // Nytt saldo: 150
            account.Withdraw(30m); // Nytt saldo: 120
            account.Deposit(20m);  // Nytt saldo: 140

            // ASSERT
            Assert.AreEqual(140m, account.Balance, "The balance should be updated correctly after multiple transactions.");
        }

    }
}
