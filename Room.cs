using System.Xml.Linq;
using System;

namespace DungeonExplorer
{
    /// <summary>
    /// Contains room number, item, item chance, item room and lists for possible items and room descriptions
    /// as well as methods to get room description, check if the room has an item and get a random item
    /// </summary>
    public class Room
    {
        public int roomNumber;

        private static readonly Random random = new Random();

        /// <summary>
        /// set the rooms default fields
        /// </summary>
        public Room()
        {
            this.roomNumber = 0;
        
        }
         
        /// <summary>
        /// displays the description of the room
        /// </summary>
        public static void GetDescription()
        {
            /*
             // generate the room description by iterating through the arrays giving more gloomy descriptions as the room number increases
            Console.WriteLine($"The walls around you are {_wallDescription[roomNumber]}, there is {_lightDescription[roomNumber]} light filling the room");
            roomNumber++;
            */
        }
    }
}