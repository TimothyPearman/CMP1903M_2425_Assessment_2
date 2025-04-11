using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// contains methods for getting and checking user input used throughout the game
    /// </summary>
    public class UserInput
    {
        /// <summary>
        /// creates a input loop to get valid user input
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
        /// checks the validity of the user input against context and the accepted values
        /// </summary>
        public static bool Check(string userInput, int iteration)
        {
            List<IEvent> events = new List<IEvent>();

            // check if user wishes to quit before proceeding
            if (userInput.ToLower() == "quit" || userInput.ToLower() == "q")
            {
                Console.Clear(); 
                Console.WriteLine($"Thanks for playing, {Player.Name}! :D"); // move to context class in future update
                Console.ReadLine(); 

                Environment.Exit(0); // exit the program
            }

            switch (iteration)
            {
                 // user name context
                case 0:
                     //Console.WriteLine("quit"); // debug

                    if (userInput == "" || userInput == null)
                    {
                        GameContext.GetContext(0);
                        return false;
                    }
                    else
                    {
                        Player.Name = userInput;
                        return true;
                    }
                     
                 // select action context (inventory, health, engage, search, move)
                case 1:
                    switch (userInput)
                    {
                        case "i":
                        case "inventory":
                             //Console.WriteLine("inventory"); // debug

                            Console.Clear();

                            Inventory.Check(); // display inventory contents
                            GameContext.GetContext(6);

                            Console.ReadLine();

                            return true;

                        case "h":
                        case "health":
                             //Console.WriteLine("health"); // debug

                            Console.Clear();
                            Player.CheckHealth(); // display player health
                            Console.ReadLine();

                            return true;

                        case "e":
                        case "engage":
                             //Console.WriteLine("engage"); // debug

                            Console.Clear();

                             // copy list of events from Room object for legibility
                            events = Map.map[Player.positionX - 1, Player.positionY - 1].events;

                             // if there is an event in the room, display to user
                            if (events.Count != 0)
                            {
                                foreach (var ev in events)
                                {
                                    Console.WriteLine(ev);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No Monsters found");
                            }

                            Console.ReadLine();

                            return true;

                        case "s":
                        case "search":
                            //Console.WriteLine("search"); // debug

                            Console.Clear();

                             // copy list of events from Room object for legibility
                            events = Map.map[Player.positionX - 1, Player.positionY - 1].events;

                             // if there is an event in the room, display to user
                            if (events.Count != 0) 
                            {
                                foreach (var ev in events)
                                {
                                    Console.WriteLine(ev);
                                }
                            }
                            else 
                            {
                                Console.WriteLine("No Items found");
                            }
                                
                            Console.ReadLine();

                            return true;

                        case "m":
                        case "move":
                            //Console.WriteLine("move"); // debug

                            Console.Clear();

                            Map.Display();
                            GameContext.GetContext(5);
                            Get(3);

                            return true;

                        default:
                            GameContext.GetContext(0); // invalid input

                            return false;
                    }

                /* // select action context (yes/no, keep,leave.drop)
                case 2:
                    if (userInput.ToLower() == "y" || userInput.ToLower() == "n")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                */

                case 3:
                    switch (userInput)
                    {
                        case "":
                        case "stay":

                            return true;

                        case "w":
                        case "up":
                            //Console.WriteLine("up"); // debug

                            // check relationship of current and target nodes
                            if (Graph.CheckUp(Player.position))
                            {
                                Player.position -= 5; // move up
                                Check("m",1);
                            }
                            else
                            {
                                Check("m", 1);
                            }

                            return true;

                        case "s":
                        case "down":
                            //Console.WriteLine("down"); // debug

                            // check relationship of current and target nodes
                            if (Graph.CheckDown(Player.position))
                            {
                                Player.position += 5; // move down
                                Check("m", 1);
                            }
                            else
                            {
                                Check("m", 1);
                            }

                            return true;

                        case "a":
                        case "left":
                            //Console.WriteLine("left"); // debug

                            // check relationship of current and target nodes
                            if (Graph.CheckLeft(Player.position))
                            {
                                Player.position -= 1; // move left
                                Check("m", 1);
                            }
                            else
                            {
                                Check("m", 1);
                            }

                            return true;

                        case "d":
                        case "right":
                            //Console.WriteLine("right"); // debug

                            // check relationship of current and target nodes
                            if (Graph.CheckRight(Player.position))
                            {
                                Player.position += 1; // move right
                                Check("m", 1);
                            }
                            else 
                            {
                                Check("m", 1);
                            }

                            return true;

                        default:
                            GameContext.GetContext(0); // invalid input

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