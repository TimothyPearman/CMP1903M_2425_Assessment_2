﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
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
            List<IEvent> events = new List<IEvent>();

            if (userInput.ToLower() == "quit" || userInput.ToLower() == "q")
            {
                Console.Clear(); 
                Console.WriteLine("Thanks for playing! :D");
                Console.ReadLine(); 

                Environment.Exit(0); // exit the program
            }

            switch (iteration)
            {
                 // user name context
                case 0:
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
                     
                 // select action context (inventory,health,move room)
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

                            events = Map.map[Player.positionX - 1, Player.positionY - 1].events;

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

                            events = Map.map[Player.positionX - 1, Player.positionY - 1].events;

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
                            GameContext.GetContext(0);

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

                case 3:
                    switch (userInput)
                    {
                        case "":
                        case "stay":

                            return true;

                        case "w":
                        case "up":
                            //Console.WriteLine("up"); // debug

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
                            GameContext.GetContext(0);

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