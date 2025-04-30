using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;

namespace DungeonExplorer
{

    /// <summary>
    /// Sets up the main gameplay structure
    /// </summary>internal
    class Game : GameContext
    { 
        public bool playing;
        public static int monsterCount = 0;

        /// <summary>
        /// sets up the game and displays initial context to the user
        /// </summary>
        public Game()
        {
            // give player sword
            Player.SetUpPlayer();

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
                List<IEvent> events = Map.map[Player.positionX - 1, Player.positionY - 1].events;

                CheckWinCondition();

                Room.CheckMonster();

                // ask user what action they would like to take in the room
                GetContext(4);
            }

             // ensure game loop is running correctly
            Debug.Assert(playing, "Game loop stopped unexpectedly!");
        }

        

        public void CheckWinCondition() 
        {
            if (monsterCount == 0)
            {
                GetContext(11); //win context
                Environment.Exit(0);
            }
        }
    }
}