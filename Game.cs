using System;
using System.Diagnostics;
using System.Media;

namespace DungeonExplorer
{
    /// <summary>
    /// Game class
    /// Sets up the main gameplay
    /// </summary>internal
    class Game : GameContext
    {
        private Room _currentRoom;
        public bool playing;

        /// <summary>
        /// Sets up game and Creates new objects for the Room and Player class
        /// </summary>
        public Game()
        {
            GetContext(0);

            GetContext(1);

            // get, validate and assign player alias
            UserInput.Get(0);

             // instantiate room object
            _currentRoom = new Room(); //change this maybe? object for each room not single(static)

             // ensure player and room objects were initialized correctly
            Debug.Assert(Player.Name != null, "Player object was not initialized correctly!");
            Debug.Assert(_currentRoom != null, "Room object was not initialized correctly!");

            GetContext(2);
        }

        /// <summary>
        /// Begins the running game logic
        /// </summary>
        public void Start()
        {
             // Change the playing logic into true and populate the while loop
            playing = true;
            while (playing)
            {
                 // display room description to user
                _currentRoom.GetDescription();

                 // ask user what action they would like to take in the room
                GetContext(3);
                 // get user input and validate it against context
                UserInput.Get(1);

                ////////////////////////////////////////////////////////////////////////
                ///                Console.WriteLine("Timmy test");

                /* 
                // check if the room will have an item
                _currentRoom.GetItemRoom();

                if (userInput == "y" && _currentRoom.itemRoom)
                {
                     // select random item in room
                    _currentRoom.GetItem();

                     // begin user input loop to get game choices
                    getUserInput = true;
                    while (getUserInput)
                    {
                        Console.WriteLine($"after a thorough search you discover a {_currentRoom.item}!");
                        Console.WriteLine("Would you like to keep it? (Y/N)");
                        userInput = Console.ReadLine();

                        // check if user input is valid
                        if (CheckUserInput(userInput, 1))
                        {
                             // ensure room item exists
                            Debug.Assert(!string.IsNullOrEmpty(_currentRoom.item), "Room item is null or empty!", "random item was not generated correctly");

                            Inventory.Add(_currentRoom.item);
                            getUserInput = false;
                            Console.Clear();
                        }
                        else 
                        {
                            Console.WriteLine("\nPlease provide a valid input");
                        }

                    }
                }
                else
                {
                    Console.WriteLine("you find nothing useful in this room and continue on\n");
                    Console.ReadKey();
                    Console.Clear();
                }
                */
            }

            // ensure game loop is running correctly
            Debug.Assert(playing, "Game loop stopped unexpectedly!");
        }
    }
}