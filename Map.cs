using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DungeonExplorer
{
    /// <summary>
    /// generates and displays the current state of the game map.
    /// </summary>
    public static class Map
    {
        public static Room[,] map;

        /// <summary>
        /// Constructor to initialize the map graph and populate each node with a room object 
        /// </summary>
        public static void Create()
        {
            //Console.WriteLine("creating Map"); // debug

            // Create a 5x5 grid to represent map
            map = new Room[5, 5];

            // Initialize each room (you can customize this further)
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int index = (i * 5) + j;
                    map[i, j] = new Room(index);
                }
            }
        }

        /// <summary>
        /// displays the current state of the game map
        /// </summary>
        public static void Display()
        {
            //Console.WriteLine("Displaying Map"); // debug
            //Graph.PrintGraph(); // debug

            Console.WriteLine("+═══════+═══════+═══════+═══════+═══════+");// top of map

            for (int h = 0; h <= 4; h++)
            {
                Console.WriteLine("║       ║       ║       ║       ║       ║ \n" +
                                  "║                                       ║ "); // upper/middle static room walls
                for (int i = 0; i < 4; i++)
                {
                    // backtrack to overwrite static room text with dynamic room walls
                    Console.Write("\x1b[A");
                    Console.Write($"\x1b[{8 * (i + 1)}C");

                    if (Graph.CheckRight((h * 5) + i))
                    {
                        Console.WriteLine(" "); // dynamic room horizontal walls
                    }
                    else
                    {
                        Console.WriteLine("║"); // dynamic room horizontal walls
                    }
                }

                // break loop as bottom walls are not valid for bottom rooms
                if (h == 4) 
                {
                    continue;
                }

                Console.WriteLine("║       ║       ║       ║       ║       ║\n" +
                                  "+       +       +       +       +       + "); // lower/bottom static room walls

                for (int j = 0; j < 5; j++)
                {
                    Console.Write("\x1b[A");
                    Console.Write($"\x1b[{(8 * j) + 1}C");

                    if (Graph.CheckDown((h * 5) + j))
                    {
                        Console.WriteLine("══   ══"); // dynamic room vertical walls
                    }
                    else
                    {
                        Console.WriteLine("═══════"); // dynamic room vertical walls
                    }
                }
            }
            Console.WriteLine("║       ║       ║       ║       ║       ║\n" +
                              "+═══════+═══════+═══════+═══════+═══════+"); // bottom of map

            // calculate player current grid position
            Player.positionX = (Player.position % 5) + 1;
            Player.positionY = (Player.position / 5) + 1;

            // backtrack cursor to the beginning of terminal then to the player position
            Console.Write("\x1b[H");
            Console.Write($"\x1b[{(Player.positionX * 8) - 4}C");
            Console.Write($"\x1b[{(Player.positionY * 4) - 2}B");
            Console.Write("O");
        }
    }

    /// <summary>
    /// generates a graph data structure and adjacency matrix to represent the map and relationships between room nodes.
    /// </summary>
    public static class Graph
    {
        private static int size = 5;
        public static Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
        private static Random random = new Random();

        /// <summary>
        /// 
        /// </summary>
        public static void Create()
        {
            for (int i = 0; i < size * size; i++)
            {
                adjList[i] = new List<int>();
            }

            RandomizeGraph();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void AddEdge(int from, int to)
        {
            if (!adjList[from].Contains(to))
            {
                adjList[from].Add(to);
                adjList[to].Add(from); // Undirected graph
            }
        }

        /// <summary>
        /// generates random connections between graph nodes
        /// </summary>
        public static void RandomizeGraph(double connectionChance = 0.5)
        {
            // ensure every node has at least one connection
            for (int pass = 0; pass < 2; pass++)
            {
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        int index = row * size + col;

                        // generate random direction node connection
                        switch (random.Next(0, 4))
                        {
                            case 0:
                                if (index > 4)
                                {
                                    AddEdge(index, index - 5); // up
                                }
                                break;

                            case 1:
                                if (index < 20)
                                {
                                    AddEdge(index, index + 5); // down
                                }
                                break;

                            case 2:
                                if (index % 5 != 0)
                                {

                                    AddEdge(index, index - 1); // left
                                }
                                break;

                            case 3:
                                if ((index % 5) - 4 != 0)
                                {
                                    AddEdge(index, index + 1); // right
                                }
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// checks if the target node has a connection to the node above it
        /// </summary>
        public static bool CheckUp(int index)
        {
            //Console.WriteLine($"checking {index} up"); // debug

            if (adjList[index].Any(neighbor => neighbor == index - 5))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// checks if the target node has a connection to the node below it
        /// </summary>
        public static bool CheckDown(int index)
        {
            //Console.WriteLine($"checking {index} down"); // debug

            if (adjList[index].Any(neighbor => neighbor == index + 5))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// checks if the target node has a connection to the node left of it
        /// </summary>
        public static bool CheckLeft(int index)
        {
            //Console.WriteLine($"checking {index} left"); // debug

            if (adjList[index].Any(neighbor => neighbor == index - 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// checks if the target node has a connection to the node right of it
        /// </summary>
        public static bool CheckRight(int index)
        {
            //Console.WriteLine($"checking {index} right"); // debug

            if (adjList[index].Any(neighbor => neighbor == index + 1))
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        /// <summary>
        /// display the relationships of each graph node, for debugging purposes
        /// </summary>
        public static void PrintGraph()
        {
            for (int i = 0; i < size * size; i++)
            {
                if (adjList.ContainsKey(i))
                {
                    Console.Write($"Node {i}: ");
                    foreach (var neighbor in adjList[i])
                    {
                        Console.Write($"{neighbor} ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"Node {i}: No connections");
                }
            }
        }
    }
} 