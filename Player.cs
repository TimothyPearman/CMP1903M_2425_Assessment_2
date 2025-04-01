using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DungeonExplorer
{
    /// <summary>
    /// Contains player's name and health as well as items in the inventory 
    /// as well as methods to display inventory and health and add to the inventory
    /// </summary>
    public class Player
    {
        public string name;
        public int health;
        private List<string> _inventory = new List<string>();

        /// <summary>
        /// allows for getting and setting of the field name
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                // ensures user cannot enter an empty name and sets a default value
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Name cannot be empty.");
                    name = "Adventurer";
                }
                else
                {
                    name = value;
                }
            }

        }

        /// <summary>
        /// allows for getting and setting of the field health
        /// </summary>
        public int Health
        {
            get { return health; }
            set
            {
                // ensures the player's health cannot fall outside the range 0-100
                if (value > 100)
                {
                    Console.WriteLine("Error: health cannot exceed the range 0-100");
                    health = 100;
                }
                else if(value < 0 )
                {
                    Console.WriteLine($"Your health is depleted, your journey ends here, {name}...");
                    Environment.Exit(0); // exit the program
                }
                else
                {
                    health = value;
                }
            }

        }

        /// <summary>
        /// sets the players default fields
        /// <param name="name">The player's chosen alias</param>
        /// </summary>
        public Player(string name) 
        {
            this.name = name;
            this.health = 100;
            _inventory.Add("Sword");
        }

        /// <summary>
        /// adds an item to the player's inventory
        /// <param name="item">The item to be added to the inventory</param>
        /// </summary>
        public void PickUpItem(string item)
        {
             // add item to player inventory array
            _inventory.Add(item);
        }

        /// <summary>
        /// displays the contents of the player's inventory
        /// </summary>
        public void InventoryContents()
        {
             // display player inventory
            Console.WriteLine(string.Join(", ", _inventory));
        }

        /// <summary>
        /// displays the player's health
        /// </summary>
        public void PlayerHealth()
        {
             // display player health
            Console.WriteLine(Health);
        }
    }
}