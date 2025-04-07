using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// contains methods for user input that are used throughout the game
    /// </summary>
    public class UserInput
    {
        /// <summary>
        /// summary
        /// </summary>
        public static void Get(int iteration)
        {
            string userInput = "";
           
             // begin user input loop to get player name
            bool getUserInput = true;
            while (getUserInput) 
            {
                 // get user input and validate it against context
                userInput = Console.ReadLine().ToLower();
                getUserInput = !Check(userInput, iteration);
            }
        }

        /// <summary>
        /// summary
        /// </summary>
        public static bool Check(string userInput, int iteration)
        {
            if (userInput.ToLower() == "quit" || userInput.ToLower() == "q")
            {
                Environment.Exit(0); // exit the program
            }

            switch (iteration)
            {
                 // user name context
                case 0:
                    if (userInput == "" || userInput == null)
                    {
                        Console.WriteLine("please enter a valid input");
                        return false;
                    }
                    else
                    {
                        Player.Name = userInput;
                        return true;
                    }

                 // select action context (inventory,health,move room)
                case 1:
                    switch (userInput)
                    {
                        case "i":
                        case "inventory":
                            //Console.WriteLine("inventory"); // debug
                            Inventory.Check(); // display inventory contents

                            return true;

                        case "h":
                        case "health":
                            //Console.WriteLine("health"); // debug
                            Player.CheckHealth(); // display player health

                            return true;

                        case "e":
                        case "engage":
                            //Console.WriteLine("engage"); // debug

                            return true;

                        case "s":
                        case "search":
                            //Console.WriteLine("search"); // debug

                            return true;

                        case "m":
                        case "move":
                            //Console.WriteLine("move"); // debug

                            return true;

                        default:
                            Console.WriteLine("please enter a valid input");

                            return false;
                    }

                 // select action context (yes/no, keep,leave.drop
                case 2:
                    if (userInput.ToLower() == "y" || userInput.ToLower() == "n")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                default:
                    // error handling
                    Console.WriteLine("Something broke :C");
                    Debug.Assert(false, "user input iteration not found");

                    break;
            }

            return true;
        }
    }
}