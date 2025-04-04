using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Item : Event
    {
        public Item()
        {
            Console.WriteLine("Item created");
        }

        public void GetEvent()
        {
            Console.WriteLine("Getting Item");
        }

        public void GetEventStats()
        {
            Console.WriteLine("Getting Item Stats");
        }
    }
}
