using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

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
            this.eventChance = 1; // 1 in 2 chance of an event occurring

            // randomly generate events for the room
            for (int j = 0; j < 2; j++) 
            {
                if ((random.Next(0, eventChance) == 0) && (roomNumber != 12)) //ensure nothing can spawn in the start room
                {
                    //Console.WriteLine("event"); // debug

                    // randomly decide if event will be of type item or monster
                    switch (random.Next(0, 2))
                    {
                        case 0:
                            events.Add(new Item());
                            break;

                        case 1:
                            events.Add(new Monster());
                            Game.monsterCount += 1; // total number of monster alive - for win condition
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
        /// displays all monsters in the room
        /// </summary>
        public static bool CheckMonster()
        {
            // copy list of events from Room object for legibility
            List<IEvent> events = Map.map[Player.positionX - 1, Player.positionY - 1].events;

            Console.Clear();

            // if there is an event in the room, display to user
            if (events.Any(e => e is Monster))
            {
                Console.WriteLine("the room is guarded by:");

                int index = 1;
                foreach (var e in events)
                {
                    //Console.WriteLine(e.EventType());

                    if (e is Monster)
                    {
                        Console.WriteLine($"{index}: {e.Type()}, {e.Stat()} hp");
                        index++;
                    }
                }

                Console.WriteLine("");

                return true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No monsters in the room\n");
                
                return false;
            }
        }
    }
} 