using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// contains and introduces methods to manage/edit the player's inventory
    /// </summary>
    public static class Inventory
    {
        public static List<Item> inventory = new List<Item>();

        /// <summary>
        /// displays the contents of the player's inventory
        /// </summary>
        public static void Check()  
        {
            //Console.WriteLine("Checking Inventory"); // debug

           
            Console.WriteLine($"{"offense",-12}: {Player.offense.type}, {Player.offense.stat}");
            Console.WriteLine($"{"defense",-12}: {Player.defense.type}, {Player.defense.stat}");
            Console.WriteLine($"{"protection",-12}: {Player.protection.type}, {Player.protection.stat}");


            Console.WriteLine("\nInventory:");

            // display player inventory
            if (inventory.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                int index = 0;
                foreach (Item i in inventory)
                {
                    Console.WriteLine($"{index + 1}: {i.type}, {i.stat}");
                    index++;
                }
            }
        }

        /// <summary>
        /// Adds an item to the player's inventory
        /// </summary>
        /// <param name="item">The item to be added to the inventory</param>
        public static void Add(Item item)
        {
            // add item to player inventory array
            inventory.Add(item);
        }

        /// <summary>
        /// Removes an item from the player's inventory at the specified index.
        /// </summary>
        /// <param name="index">The index of the item to be removed from the inventory</param>
        public static void Remove(string index)
        {
            inventory.RemoveAt(Convert.ToInt32(index));  
        }
    }
}
 