using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// summary
    /// </summary>
    public abstract class GameContext : GameMap
    {
        /// <summary>
        /// display game lore and context to the user
        /// </summary>
        public void GetContext(int iteration)
        {
            switch (iteration)
            {
                case 0:
                    // explain how the game works and rules the to user 
                    Console.WriteLine("this is a dungeon explorer game where you progress through rooms and gather equipment");
                    Console.WriteLine("you may use \"inventory\" to check what items you have aquired\nand \"health\" to see your remaining health\n");

                    Console.WriteLine("you can also use \"quit\" at any time to end the game");
                    Console.WriteLine("press anywhere to start the game...");
                    // wait for user input to start the game
                    Console.ReadKey();
                    // clear the console to start the game fresh
                    Console.Clear();

                    break;

                case 1:
                     // asks user for alias
                    Console.WriteLine("Awakening on a cold floor, a pounding headache clouds any clear thought\nYou can barely remember your name: ");
                    
                    break;

                case 2:
                     // informs the user that they have a sword and have moved onto the next room
                    Console.Clear();
                    Console.WriteLine("pulling yourself to your feet, you begin to examine your surroundings\n");
                    Console.WriteLine("The walls caging you seem well kept, bathed by countless torches");
                    Console.WriteLine("You notice a sword displayed in the center of the room, and grab it as you march onward into the next room...");
                    Inventory.Add("sword");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 3:
                    // asks user for what action they would like to take (inventory/health/engage/search/move)
                    Console.WriteLine("\nActions: \n-inventory \n-health \n-engage \n-search \n-move ");
                    //UserInput.Get(?);

                    break;

                case 4:
                    // asks user for what action they would like to take (attack/block/run) - monster
                    Console.WriteLine("\nActions: \n-attack \n-block \n-run");
                    //UserInput.Get(?);

                    break;

                case 5:
                    // asks user for what action they would like to take (take/leave/drop) - item
                    Console.WriteLine("\nActions: \n-take \n-leave \n-drop");
                    //UserInput.Get(?);

                    break;


                default:
                    // error handling
                    Console.WriteLine("Something broke :C");
                    Debug.Assert(false, "game context iteration not found");

                    break;
            }
        }
    }
}


