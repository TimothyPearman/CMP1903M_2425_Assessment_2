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
    public abstract class GameMap
    {
        /// <summary>
        /// summary
        /// </summary>
        public GameMap()
        {
            //Console.WriteLine("GameMap created"); // debug
        }

        /// <summary>
        /// displays the map of the current game in the terminal window
        /// </summary>
        public void GetMap()
        {
            Console.WriteLine("Getting Map");
        }
    }
}
