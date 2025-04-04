using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Monster : Event
    {
        public Monster()
        {
            Console.WriteLine("Monster created");
        }

        public void GetEvent()
        {
            Console.WriteLine("Getting Monster");
        }

        public void GetEventStats()
        {
            Console.WriteLine("Getting Monster Stats");
        }
    }
}