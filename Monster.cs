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
        string[] itemTypes = { "zombie", "skeleton", "spider", };
        public string type;
        public int stat;

        private static readonly Random random = new Random();

        /// <summary>
        /// constructor for monster object that generates the type of monster
        /// </summary>
        public Monster()
        {
            //Console.WriteLine("Monster created"); // debug

             // randomly generate item type and health and attack
            type = itemTypes[random.Next(0, itemTypes.Length)];
            stat = 100 + random.Next(0, 100);
        }

        /// <summary>
        /// returns item type
        /// </summary>
        public string Type()
        {
            //Console.WriteLine("Getting monster type"); // debug

            return type;
        }

        /// <summary>
        /// returns item stat
        /// </summary> 
        public int Stat()
        {
            //Console.WriteLine("Getting Monster Stats"); // debug

            return stat;
        }
    }
} 