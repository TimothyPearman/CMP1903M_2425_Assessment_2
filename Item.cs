using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// defines an item object and its properties
    /// </summary>
    public class Item : IEvent
    {
        string[] itemTypes = { "sword", "shield", "armour", "potion", "key", "pile of gold", "Torch", "Lockpick", };
        public string type;
        public int stat;
        

        private static readonly Random random = new Random();

        /// <summary>
        /// constructor for item objectt hat generates the type of item
        /// </summary>
        public Item()
        {
            //Console.WriteLine("Item created"); // debug

            // randomly generate item type
            type = itemTypes[random.Next(0, itemTypes.Length)];
            stat = 100 + random.Next(0, 100);
            
        }

        /// <summary>
        /// displays the type of the object
        /// </summary>
        public string Type()
        {
            //Console.WriteLine("Getting Item type"); // debug

            return type;
        }

        /// <summary>
        /// displays the properties of the object
        /// </summary>
        public int Stat()
        {
            //Console.WriteLine("Getting Item Stats"); // debug

            return stat;
        }
    }
}
 