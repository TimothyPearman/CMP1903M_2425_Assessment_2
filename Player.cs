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
        public static string name;
        public static int health = 100;
        public static Item offense = new Item(); // sword
        public static Item defense = new Item(); // shield
        public static Item protection = new Item(); // armour

        public static int position = 12;
        public static int positionX = 3;
        public static int positionY = 3;

        /// <summary>
        /// sets up the players default fields
        /// </summary>
        public static void SetUpPlayer()
        {
            offense.type = "sword";
            offense.stat = 1000;
            defense.type = "shield";
            defense.stat = 50;
            protection.type = "armour";
            protection.stat = 0;
        }


        /// <summary>
        /// displays the player's health
        /// </summary>
        public static void CheckHealth()
        {
            // display player health
            Console.WriteLine($"health: {health}"); 
        }
    }
} 