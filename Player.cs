using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DungeonExplorer
{
    /// <summary>
    /// Contains the player's name, health and grid and node map positions
    /// </summary>
    public static class Player
    {
        public static string Name;
        public static int Health = 100;
        public static int position = 12;
        public static int positionX = 3;
        public static int positionY = 3;

        /// <summary>
        /// displays the player's health
        /// </summary>
        public static void CheckHealth()
        {
             // display player health
            Console.WriteLine(Health); 
        }
    }
}