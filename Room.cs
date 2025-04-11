using System.Xml.Linq;
using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    /// <summary>
    /// Contains the number of the map node it is assigned to, and a list of events within the room
    /// as well as methods to get room description, check if the room has an item and get a random item
    /// </summary>
    public class Room
    {
        public int roomNumber;
        public int eventChance;
        public List<IEvent> events = new List<IEvent>();

        private static readonly Random random = new Random();

        /// <summary>
        /// set the rooms default fields
        /// </summary>
        public Room(int index)
        {
            this.roomNumber = index;
            this.eventChance = 3; // 1 in 3 chance of an event occurring

            // randomly generate events for the room
            for (int j = 0; j < 2; j++) 
            {
                if (random.Next(0, eventChance) == 0)
                {
                    //Console.WriteLine("event"); // debug

                    switch(random.Next(0, 2))
                    {
                        case 0:
                            events.Add(new Item());
                            break;

                        case 1:
                            events.Add(new Monster());
                            break;

                        default:
                            break;
                    }
                }
                else 
                {
                    //Console.WriteLine("no event"); // debug
                }
            }
        }

        /// <summary>
        /// displays the events within the room
        /// </summary>
        public static void GetDescription()
        {
            // move event display from userinput class to here in later version 
        }
    }
} 