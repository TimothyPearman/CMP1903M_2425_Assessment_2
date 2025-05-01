using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
        private static readonly Random random = new Random();

        /// <summary>
        /// creates a input loop to get valid user input
        /// </summary>
        public static void Get(int iteration, int inputType = 0)
        {
            string userInput = "";
           
             // begin user input loop to get player name
            bool getUserInput = true;
            while (getUserInput) 
            {
                 // get user input and validate it against context
                if (inputType == 0)
                {
                    userInput = Console.ReadLine().ToLower();
                }
                else
                {
                    userInput = Console.ReadKey().Key.ToString().ToLower();
                }
                    
                getUserInput = !Check(userInput, iteration);
            }
        }

        /// <summary>
        /// checks the validity of the user input against accepted values
        /// </summary>
        public static bool Check(string userInput, int iteration)
        {
            List<IEvent> events = new List<IEvent>();

            // check if user wishes to quit before proceeding
            if (userInput.ToLower() == "quit" || userInput.ToLower() == "q")
            {
                Console.Clear(); 
                Console.WriteLine($"Thanks for playing, {Player.name}! :D"); // move to context class in future update
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
                        Player.name = userInput;
                        return true;
                    }
                     
                 // action option (inventory, health, engage, search, move)
                case 1:
                    switch (userInput)
                    {
                        case "i":
                        case "inventory":
                             //Console.WriteLine("inventory"); // debug

                            Console.Clear();

                            Inventory.Check(); // display inventory contents
                            GameContext.GetContext(5);

                            return true;

                        case "h":
                        case "health":
                             //Console.WriteLine("health"); // debug

                            Console.Clear();
                            Player.CheckHealth(); // display player health

                            List<Item> inventory = Inventory.inventory;
                            List<Item> items = new List<Item>();

                            // compile all items of type potion into a list
                            int index = 0;
                            foreach (Item i in inventory.Where(i => i.type == "potion"))
                            {
                                items.Add(i);
                                index++;
                            }


                            if (items.Count == 0)
                            {
                                Console.WriteLine("no items");
                            }
                            else
                            {
                                index = 0;
                                foreach (Item i in items)
                                {
                                    Console.WriteLine($"{index + 1}: {i.Type()}, {i.Stat()}");

                                    index++;
                                }
                                GameContext.GetContext(6);
                            }

                            Console.ReadLine();

                            return true;

                        case "e":
                        case "engage":
                            //Console.WriteLine("engage"); // debug

                            if (Room.CheckMonster()) 
                            {
                                GameContext.GetContext(7);
                            }

                            return true;

                        case "s":
                        case "search":
                            //Console.WriteLine("search"); // debug

                            Console.Clear();

                            // copy list of events from Room object for legibility
                            events = Map.map[Player.positionX - 1, Player.positionY - 1].events;

                            //check if monster is in room, if so, no searchy
                            if (events.Any(e => e is Monster))
                            {
                                GameContext.GetContext(9);
                                return true;
                            }
                            
                            // display if there is an item in the room
                            if (events.Any(e => e is Item))
                            {
                                Console.WriteLine("the room contains:");

                                // display all events of type item
                                index = 0;
                                foreach (var e in events)
                                {
                                    if (e is Item)
                                    {
                                        Console.WriteLine($"{index+1}: {e.Type()}, {e.Stat()}");

                                        index++;
                                    }
                                }

                                GameContext.GetContext(8);
                            }
                            else 
                            {
                                Console.WriteLine("No Items found in the room");
                                Console.ReadLine();
                            }
                                
                            return true;

                        case "m":
                        case "move":
                            //Console.WriteLine("move"); // debug

                            Console.Clear();

                            Map.Display();
                            GameContext.GetContext(10);
                            Get(6, 1);

                            return true;

                        default:
                            GameContext.GetContext(0); // invalid input

                            return false;
                    }

                // inventory actions (equip, drop)
                case 2:
                    switch (userInput)
                    {
                        case "enter":
                        case "":
                        case "leave":

                            return true;

                        case "e":
                        case "equip":
                            //Console.WriteLine("equip"); // debug

                            Console.WriteLine("which item would you like to equip?\n");

                            int index = 0;
                            while ((index == 0) || (index > Inventory.inventory.Count()))
                            {
                                try
                                {
                                    index = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    return false;
                                }
                            }

                            Item item = Inventory.inventory[index - 1];

                            if ((item.Type() == "sword") || (item.Type() == "shield") || (item.Type() == "armour"))
                            {
                                Item newItem = Inventory.inventory[index - 1];
                                Item currentItem;

                                switch (newItem.Type())
                                {
                                    case "sword":
                                        //Console.WriteLine("sword"); // debug

                                        // update player item, remove item from inventory and add previous player item to inventory
                                        currentItem = Player.offense;
                                        Player.offense = newItem as Item;
                                        Inventory.inventory.RemoveAt(index - 1);
                                        Inventory.inventory.Add(currentItem);

                                        break;

                                    case "shield":
                                        //Console.WriteLine("shield"); // debug

                                        currentItem = Player.defense;
                                        Player.defense = newItem as Item;
                                        Inventory.inventory.RemoveAt(index - 1);
                                        Inventory.inventory.Add(currentItem);

                                        break;

                                    case "armour":
                                        //Console.WriteLine("armour"); // debug

                                        currentItem = Player.protection;
                                        Player.protection = newItem as Item;
                                        Inventory.inventory.RemoveAt(index - 1);
                                        Inventory.inventory.Add(currentItem);

                                        break;

                                    default:
                                        GameContext.GetContext(0); // invalid input

                                        return false;
                                }
                            }
                            else
                            {
                                index = 0;
                                GameContext.GetContext(0);
                                Console.ReadLine();
                            }

                            Check("inventory", 1);

                            return true;

                        case "d":
                        case "drop":
                            //Console.WriteLine("drop"); // debug

                            Console.WriteLine("which item would you like to drop?\n");

                            index = 0;
                            while ((index == 0) || (index > Inventory.inventory.Count()))
                            {
                                try
                                {
                                    index = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    return false;
                                }
                            }

                            //removes item from inventory and adds it to the room
                            item = Inventory.inventory[index - 1];
                            Room room = Map.map[Player.positionX - 1, Player.positionY - 1];
                            room.events.Add(item);
                            Inventory.inventory.RemoveAt(index - 1);

                            return true;

                        default:
                            GameContext.GetContext(0); // invalid input

                            return false;
                    }

                // health actions (use)
                case 3:
                    switch (userInput)
                    {
                        case "enter":
                        case "":
                        case "leave":

                            return true;

                        case "u":
                        case "use":
                            //Console.WriteLine("use"); // debug

                            List<Item> inventory = Inventory.inventory;
                            List<Item> items = new List<Item>();

                            // compile all items of type potion into a list
                            int index = 0;
                            foreach (Item i in inventory.Where(i => i.type == "potion"))
                            {
                                items.Add(i);
                                index++;
                            }

                            Console.WriteLine("which item would you like to use"); 

                            index = 0;
                            while ((index == 0) || (index > items.Count()))
                            {
                                try
                                {
                                    index = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    return false;
                                }
                            }

                            Item item = items[index - 1];

                            Player.health += item.Stat();
                            Inventory.inventory.RemoveAt(index - 1);

                            Check("health", 1);

                            return true;

                        default:
                            GameContext.GetContext(0); // invalid input

                            return false;
                    }

                // engagge actions (attack, block, run)
                case 4:
                    switch (userInput)
                    {
                        case "enter":
                        case "":
                        case "leave":

                            return true;

                        case "a":
                        case "attack":
                            //Console.WriteLine("attack"); // debug

                            Room room = Map.map[Player.positionX - 1, Player.positionY - 1];
                            events = room.events;
                            List<Monster> monsters = new List<Monster>();

                            // compile all events of type monster into a list
                            int index = 0;
                            foreach (var e in events)
                            {
                                if (e is Monster)
                                {
                                    monsters.Add(e as Monster);
                                    index++;
                                }
                            }

                            Console.WriteLine("which monster would you like to attack");

                            // validate user input 
                            index = 0;
                            while ((index == 0) || (index > monsters.Count()))
                            {
                                try
                                {
                                    index = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    return false;
                                }
                            }

                            monsters[index - 1].stat -= Player.offense.Stat();
                            Console.WriteLine($"you attack the {monsters[index - 1].Type()} for {Player.offense.Stat()} damage!");
                            
                            // check if monster health is depleted and delete it
                            if (monsters[index - 1].Stat() <= 0)
                            {
                                room.events.Remove(monsters[index - 1]);
                                Game.monsterCount -= 1;
                                Console.WriteLine("you have slain the monster");
                            }

                            //chance for monster to attack back
                            else if (random.Next(0, 2) == 0)
                            {
                                int damage = random.Next(0, 100) - ((Player.defense.stat / 2) + ((Player.protection.stat+2) / 2)-1);

                                if (damage <= 0) 
                                {
                                    damage = 0;
                                }
                                Player.health -= damage;

                                Console.WriteLine($"The monster strikes back and you lose {damage} health!");

                                // check if player health is depleted and end game
                                if (Player.health <= 0) 
                                {
                                    Console.WriteLine($"you have been slain! this is the end of your adventure, {Player.name}");
                                    Console.ReadLine();

                                    Environment.Exit(0); // exit the program
                                }
                            }

                            Console.ReadLine();

                            Check("engage", 1);

                            return true;

                        case "b":
                        case "block":
                            //Console.WriteLine("block"); // debug

                            room = Map.map[Player.positionX - 1, Player.positionY - 1];
                            events = room.events;
                            monsters = new List<Monster>();

                            // compile all events of type monster into a list
                            index = 0;
                            foreach (var e in events)
                            {
                                if (e is Monster)
                                {
                                    monsters.Add(e as Monster);
                                    index++;
                                }
                            }

                            Console.WriteLine("which monster would you like to block");

                            // validate user input 
                            index = 0;
                            while ((index == 0) || (index > monsters.Count()))
                            {
                                try
                                {
                                    index = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    return false;
                                }
                            }



                            //chance for monster to attck, if it does then you take half damage, and have a chance to attack for double
                            if (random.Next(0, 2) == 0)
                            {
                                int damage = (random.Next(0, 100) - ((Player.defense.stat / 2) + ((Player.protection.stat + 2) / 2) - 1)) / 2;

                                if (damage <= 0)
                                {
                                    damage = 0;
                                }
                                Player.health -= damage;

                                Console.WriteLine($"The monster strikes and you lose {damage} health!");

                                // check if player health is depleted and end game
                                if (Player.health <= 0)
                                {
                                    Console.WriteLine($"you have been slain! this is the end of your adventure, {Player.name}");
                                    Console.ReadLine();

                                    Environment.Exit(0); // exit the program
                                }

                                if (random.Next(0, 2) == 0)
                                {
                                    monsters[index - 1].stat -= Player.offense.Stat();
                                    Console.WriteLine($"you find an opening and attack the {monsters[index - 1].Type()} for {Player.offense.Stat()*1.5} damage!");

                                    // check if monster health is depleted and delete it
                                    if (monsters[index - 1].stat <= 0)
                                    {
                                        room.events.Remove(monsters[index - 1]);
                                        Game.monsterCount -= 1;
                                        Console.WriteLine("you have slain the monster");
                                    }
                                }
                            }
                            else 
                            {
                                Console.WriteLine("the monster does not attack");

                            }


                            Console.ReadLine();

                            Check("engage", 1);

                            return true;

                        default:
                            GameContext.GetContext(0); // invalid input

                            return false;
                    }

                // search actions (take, leave)
                case 5:
                    switch (userInput)
                    {
                        case "enter":
                        case "":
                        case "leave":

                            return true;

                        case "t":
                        case "take":
                            //Console.WriteLine("take"); // debug
                            Room room = Map.map[Player.positionX - 1, Player.positionY - 1];
                            events = room.events;
                            List<IEvent> items = new List<IEvent>();
                            List<int> indexes = new List<int>();

                            // compile all events of type item into a list
                            int index = 0;
                            foreach (var e in events)
                            {
                                if (e is Item)
                                {
                                    items.Add(e);
                                    indexes.Add(index);
                                }
                                index++;
                            }

                            index = 0;

                            Console.WriteLine($"\nwhich item would you like to take?");
                            while ((index == 0) || (index > items.Count()))
                            {
                                try
                                {
                                    index = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    return false;
                                }
                            }

                            // add item to inventory and remove it from the room
                            Inventory.inventory.Add(items[index - 1] as Item);
                            room.events.RemoveAt(indexes[index - 1]);

                            Console.Clear();
                            Check("search", 1);
                            
                            return true;

                        default:
                            GameContext.GetContext(0); // invalid input

                            return false;
                    }

                // move actions (stay, up, down, left, right)
                case 6: //was 3
                    switch (userInput)
                    {
                        case "enter":
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