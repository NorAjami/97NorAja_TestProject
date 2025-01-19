using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _97NorAja_TestProject.Uppgift5
{
    public class BankAccount
    {
     
        // Egenskap för att hålla saldot
        public decimal Balance { get; private set; }

        // Metod för insättning
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero.", nameof(amount));
            }

            Balance += amount;
        }

        // Metod för uttag
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero.", nameof(amount));
            }

            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }

            Balance -= amount;
        }
        
    }
}

