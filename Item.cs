using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Item
    {
        public Item()
        {
            Console.WriteLine("Item created");
        }

        public static void GetItem()
        {
            Console.WriteLine("Getting Item");
        }

        public static void GetItemStats()
        {
            Console.WriteLine("Getting Item Stats");
        }
    }
}
