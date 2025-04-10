using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DungeonExplorer
{
    /// <summary>
    /// Contains player's name and health as well as items in the inventory 
    /// as well as methods to display inventory and health and add to the inventory
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