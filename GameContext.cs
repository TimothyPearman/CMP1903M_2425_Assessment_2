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
                    Console.ReadKey();
                    break;

                 // actions context
                case 4:
                    // asks user for what action they would like to take (inventory/health/engage/search/move)
                    Console.WriteLine("Actions: \n-Inventory (I)\n-Health (H)\n-Engage (E)\n-Search (S)\n-Move (M)");
                    Console.WriteLine("\x1b[B");
                    UserInput.Get(1);

                    break;

                // inventory actions context
                case 5:
                    // asks user for what action they would like to take (equip/drop)
                    Console.WriteLine("\nActions: \n-Equip (E)\n-Drop (D)");
                    UserInput.Get(2);

                    break;

                // health actions context
                case 6:
                    // asks user for what action they would like to take (use)
                    Console.WriteLine("\nActions: \n-Use (u)");
                    UserInput.Get(3);

                    break;

                // engage actions context
                case 7:
                    // asks user for what action they would like to take (attack/block/run) - monster
                    Console.WriteLine("Actions: \n-Attack (A)\n-Block (B)");
                    UserInput.Get(4);

                    break;

                // search actions context
                case 8:
                    // asks user for what action they would like to take (take/leave) - item
                    Console.WriteLine("\nActions: \n-Take (T)\n\n");
                    UserInput.Get(5);

                    break;

                // search context (monster in room)
                case 9:
                    Console.WriteLine("Cannot search the room, a monster guards it...");
                    Console.ReadLine();
                    //UserInput.Get(?);

                    break;

                // move actions context
                case 10:
                    Console.Write("\x1b[H");
                    Console.Write($"\x1b[22B");
                    Console.WriteLine("Actions: \n-Up (w) \n-Down (s) \n-Left (a) \n-Right (d)");
                    //UserInput.Get(?);

                    break;

                // win context
                case 11:
                    Console.Clear();
                    Console.WriteLine($"congratulations {Player.name}, you have slain all enemies with this dungeon! you may now exit this place...");
                    Console.ReadLine();

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


 