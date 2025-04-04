using System;
using System.Collections.Generic;
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
        public static void GetInput()
        {
            /*
            // begin user input loop to get player name
            bool getUserInput = true;
            while (getUserInput)
            {
                string userInput = Console.ReadLine();

                if (CheckUserInput(userInput, 0))
                {
                    getUserInput = false;
                    continue;
                }
                Console.WriteLine("please enter a valid name");
            }
            */
        }

        public static void CheckUserInput(string userInput, int inputContext)
        {
            /*
            if (inputContext == 0)
            { // name context
                if (userInput == "" || userInput == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            */
        }
    }
}