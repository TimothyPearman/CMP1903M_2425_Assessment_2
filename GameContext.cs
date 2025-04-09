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
    public abstract class GameContext
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
                    Console.WriteLine("This is a dungeon explorer game where you traverse a maze");
                    Console.WriteLine("Gather equipment, battle monsters and \x1b[31m\x1b[5msurvive\x1b[0m");
                    Console.WriteLine("you may use \"quit\" at any time to end the game");

                    Console.WriteLine("\n\u001b[5mpress anywhere to start the game...\u001b[0m");
                    // wait for user input to start the game
                    Console.ReadKey();
                    // clear the console to start the game fresh
                    Console.Clear();

                    break;

                case 1:
                     // asks user for alias
                    Console.WriteLine("Awakening on a cold floor, a pounding headache clouds any clear thought");
                    Console.WriteLine("\n\u001b[5mYou can barely remember your name: \u001b[0m");

                    break;

                case 2:
                     // informs the user that they have a sword and have moved onto the next room
                    Console.Clear();
                    Console.WriteLine("Pulling yourself to your feet, you begin to examine your surroundings");
                    Console.WriteLine("The walls caging you seem well kept, bathed by countless torches");
                    Console.WriteLine("Acknowledging the sword displayed in the center of the room");
                    Console.WriteLine("You grab it and prepare to move onward...");
                    Inventory.Add("sword");
                    Console.ReadKey();
                    break; 

                case 3:
                    // asks user for what action they would like to take (inventory/health/engage/search/move)
                    Console.WriteLine("Actions: \n-Inventory (I)\n-Health (H)\n-Engage (E)\n-Search (S)\n-Move (M)\n-Map");
                    //UserInput.Get(?);

                    break;

                case 4:
                    // asks user for what action they would like to take (attack/block/run) - monster
                    Console.WriteLine("Actions: \n-Attack (A)\n-Block (B)\n-Run (R)");
                    //UserInput.Get(?);

                    break;

                case 5:
                    // asks user for what action they would like to take (take/leave/drop) - item
                    Console.WriteLine("\nActions: \n-Take (T)\n-Leave (L)\n-Drop (D)");
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


