using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// summary
    /// </summary>
    public static class Inventory
    {
        public static List<string> inventory = new List<string>();

        /// <summary>
        /// displays the contents of the player's inventory
        /// </summary>
        public static void Check() 
        {
            // display player inventory
            Console.WriteLine(string.Join(", ", inventory));
        }

        /// <summary>
        /// Adds an item to the player's inventory
        /// </summary>
        /// <param name="item">The item to be added to the inventory</param>
        public static void Add(string item)
        {
            // add item to player inventory array
            inventory.Add(item);
        }

        /// <summary>
        /// Removes an item from the player's inventory at the specified index.
        /// </summary>
        /// <param name="index">The item to be removed from the inventory</param>
        public static void Remove(string index)
        {
            inventory.RemoveAt(Convert.ToInt32(index));  
        }
    }
}
