using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _97NorAja_TestProject.Uppgift6
{
    public class InventoryManager
    {
        
        // Dictionary för att lagra artiklar och deras kvantitet
        private Dictionary<string, int> _inventory = new Dictionary<string, int>();

        // Metod för att lägga till artiklar i lagret
        public void AddItem(string itemName, int quantity)
        {
            if (string.IsNullOrWhiteSpace(itemName))
                throw new ArgumentException("Item name cannot be null or empty.", nameof(itemName)); 

            if (quantity < 0) // Kontrollera att kvantiteten inte är negativ
                throw new ArgumentException("Quantity cannot be negative.", nameof(quantity));

            if (_inventory.ContainsKey(itemName))
                _inventory[itemName] += quantity;
            else
                _inventory[itemName] = quantity;
        }


        // Metod för att ta bort artiklar från lagret
        public void RemoveItem(string itemName, int quantity)
        {
            // Kontrollera att artikelnamn inte är null eller tomt
            if (string.IsNullOrWhiteSpace(itemName))
                throw new ArgumentException("Item name cannot be null or empty.", nameof(itemName));

            // Kontrollera att kvantiteten är positiv
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));

            // Kontrollera att artikeln finns i lagret
            if (!_inventory.ContainsKey(itemName) || _inventory[itemName] < quantity)
                throw new InvalidOperationException("Not enough items in stock to remove.");

            // Minska kvantiteten och ta bort artikeln om den når 0
            _inventory[itemName] -= quantity;
            if (_inventory[itemName] == 0)
                _inventory.Remove(itemName);
        }

        // Metod för att hämta kvantiteten för en specifik artikel
        public int GetQuantity(string itemName)
        {
            // Kontrollera att artikeln finns i lagret
            if (!_inventory.ContainsKey(itemName))
                throw new InvalidOperationException("Item not found in inventory.");

            return _inventory[itemName]; // Returnera kvantiteten
        }

        // Metod för att få en lista över artiklar som är slut i lagret
        public List<string> GetOutOfStockItems()
        {
            var outOfStockItems = new List<string>();

            foreach (var item in _inventory)
            {
                if (item.Value == 0)
                    outOfStockItems.Add(item.Key);
            }

            return outOfStockItems;
        }
      
    }
}

