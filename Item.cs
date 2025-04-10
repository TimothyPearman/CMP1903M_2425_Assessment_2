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
        /// <summary>
        /// constructor for item object
        /// </summary>
        public Item()
        {
            //Console.WriteLine("Item created"); // debug
        }

        /// <summary>
        /// displays the properties of the object
        /// </summary>
        public void GetEventStats()
        {
            Console.WriteLine("Getting Item Stats"); // debug
        }
    }
}
