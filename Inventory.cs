using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Inventory
    {
        public Inventory()
        {
            Console.WriteLine("Inventory created");
            List<Item> inventory = new List<Item>();
        }

        public static void Check() 
        {
            Console.WriteLine("Checking inventory");
        }

        public static void Add()
        {
            Console.WriteLine("Add to inventory");
        }

        public static void Remove()
        {
            Console.WriteLine("Remove from inventory");
        }
    }
}
