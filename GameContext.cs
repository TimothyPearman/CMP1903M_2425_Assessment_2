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
    /// contains most of all text to be displayed during run time
    /// </summary>
    public abstract class GameContext
    {
        /// <summary>
        /// display game lore and context to the user
        /// </summary>
        public static void GetContext(int iteration)
        {
            switch (iteration)
            {
                case 0:
                    // asks user for what action they would like to take (take/leave/drop) - item
                    Console.WriteLine("\x1b[3A");
                    Console.WriteLine("please enter a valid input");

                    break;
                
                case 1:
                    // explain how the game works and rules the to user 
                    Console.WriteLine("This is a dungeon explorer game where you traverse a maze");
                    Console.WriteLine("Gather equipment, battle monsters and \x1b[31m\x1b[5msurvive\x1b[0m");
                    Console.WriteLine("you may use \"quit\" or \"q\" at any time to end the game");

                    Console.WriteLine("\n\u001b[5mpress anywhere to start the game...\u001b[0m");
                    // wait for user input to start the game
                    Console.ReadKey();
                    // clear the console to start the game fresh
                    Console.Clear();

                    break;

                case 2:
                     // asks user for alias
                    Console.WriteLine("Awakening on a cold floor, a pounding headache clouds any clear thought");
                    Console.WriteLine("\n\u001b[5mYou can barely remember your name: \u001b[0m");
                    Console.WriteLine("\x1b[B");

                    break;

                case 3:
                     // informs the user that they have a sword and have moved onto the next room
                    Console.Clear();
                    Console.WriteLine("Pulling yourself to your feet, you begin to examine your surroundings");
                    Console.WriteLine("The walls caging you seem well kept, bathed by countless torches");
                    Console.WriteLine("Acknowledging the sword displayed in the center of the room");
                    Console.WriteLine("You grab it and prepare to move onward...");
                    Inventory.Add("sword");
                    Console.ReadKey();
                    break; 

                case 4:
                    // asks user for what action they would like to take (inventory/health/engage/search/move)
                    Console.WriteLine("Actions: \n-Inventory (I)\n-Health (H)\n-Engage (E)\n-Search (S)\n-Move (M)");
                    Console.WriteLine("\x1b[B");
                    //UserInput.Get(?);

                    break;

                case 5:
                    // asks user for what action they would like to take //map move options
                    Console.Write("\x1b[H");
                    Console.Write($"\x1b[22B");
                    Console.WriteLine("Actions: \n-Stay \n-Up (w) \n-Down (s) \n-Left (a) \n-Right (d)");
                    //UserInput.Get(?);

                    break;

                case 6:
                    // asks user for what action they would like to take//inventory management options
                    Console.WriteLine("\nActions: \n-Equip (A)\n-Drop (D)");
                    //UserInput.Get(?);

                    break;

                case 7:
                    // asks user for what action they would like to take (attack/block/run) - monster
                    Console.WriteLine("Actions: \n-Attack (A)\n-Block (B)\n-Run (R)");
                    //UserInput.Get(?);

                    break;

                case 8:
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


 