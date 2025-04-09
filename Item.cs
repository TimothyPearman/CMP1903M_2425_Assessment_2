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
    public class Item : Event
    {
        /// <summary>
        /// summary
        /// </summary>
        public Item()
        {
            Console.WriteLine("Item created");
        }

        /// <summary>
        /// summary
        /// </summary>
        public void GetEvent() 
        {
            Console.WriteLine("Getting Item");
        }

        /// <summary>
        /// summary
        /// </summary>#
        public void GetEventStats()
        {
            Console.WriteLine("Getting Item Stats");
        }
    }
}
