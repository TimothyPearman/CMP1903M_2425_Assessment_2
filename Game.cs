using System;
using System.Diagnostics;
using System.Media;

namespace DungeonExplorer
{
    /// <summary>
    /// Sets up the main gameplay structure
    /// </summary>internal
    class Game : GameContext
    {
        public bool playing;

        /// <summary>
        /// sets up the game and displays initial context to the user
        /// </summary>
        public Game()
        {
             // create the game map
            Graph.Create();
            Map.Create();

             // display text to the user
            GetContext(1);

            GetContext(2);

             // get, validate and assign player alias
            UserInput.Get(0);

            GetContext(3);
        }

        /// <summary>
        /// Begins the game loop running logic
        /// </summary>
        public void Start()
        {
             // Change the playing logic into true and populate the while loop
            playing = true; 
            while (playing)
            {

                 // ask user what action they would like to take in the room
                Console.Clear();

                GetContext(4);

                 // get user input and validate it against context
                UserInput.Get(1);
            }

             // ensure game loop is running correctly
            Debug.Assert(playing, "Game loop stopped unexpectedly!");
        }
    }
}