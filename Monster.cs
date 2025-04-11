using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// defines a monster object and its properties
    /// </summary>
    public class Monster : IEvent
    {
        /// <summary>
        /// constructor for monster object
        /// </summary>
        public Monster()
        {
            //Console.WriteLine("Monster created"); // debug
        }

        /// <summary>
        /// displays the properties of the object
        /// </summary> 
        public void GetEventStats()
        {
            Console.WriteLine("Getting Monster Stats"); // debug
        }
    }
} 