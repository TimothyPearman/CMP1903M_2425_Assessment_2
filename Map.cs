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
    ///  Class representing the map
    /// </summary>
    public static class Map
    {
        private static Room[,] map;

        /// <summary>
        /// Constructor to initialize the map graph and populate each node with a room object 
        /// </summary>
        public static void Create()
        {
            //Console.WriteLine("creating Map");

            // Create a 5x5 map
            map = new Room[5, 5];

            // Initialize each room (you can customize this further)
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    map[i, j] = new Room { }; // Just an example initialization
                }
            }
        }

        /// <summary>
        /// displays the map of the current game in the terminal window
        /// </summary>
        public static void Display()
        {
            //Console.WriteLine("Displaying Map"); //debug
            //Graph.PrintGraph(); 

            Console.WriteLine("+═══════+═══════+═══════+═══════+═══════+");//top

            for (int h = 0; h <= 4; h++)
            {
                Console.WriteLine("║       ║       ║       ║       ║       ║ ");
                Console.WriteLine("║                                       ║ ");
                for (int i = 0; i < 4; i++)
                {
                    Console.Write("\x1b[A");
                    Console.Write($"\x1b[{8 * (i + 1)}C");

                    if (Graph.CheckRight((h * 5) + i))
                    {
                        Console.WriteLine(" ");
                    }
                    else
                    {
                        Console.WriteLine("║");
                    }
                }

                if (h == 4) 
                {
                    continue;
                }

                Console.WriteLine("║       ║       ║       ║       ║       ║ ");
                Console.WriteLine("+       +       +       +       +       + ");

                for (int j = 0; j < 5; j++)
                {
                    Console.Write("\x1b[A");
                    Console.Write($"\x1b[{(8 * j) + 1}C");

                    if (Graph.CheckDown((h * 5) + j))
                    {
                        Console.WriteLine("══   ══");
                    }
                    else
                    {
                        Console.WriteLine("═══════");
                    }
                }
            }
            Console.WriteLine("║       ║       ║       ║       ║       ║\n" +
                              "+═══════+═══════+═══════+═══════+═══════+"); //bottom

            Console.ReadLine();
            Console.Clear();
        }
    }

    public static class Graph
    {
        private static int size = 5;
        public static Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
        private static Random random = new Random();

        public static void Create()
        {
            for (int i = 0; i < size * size; i++)
            {
                adjList[i] = new List<int>();
            }

            RandomizeGraph();
        }

        public static void AddEdge(int from, int to)
        {
            if (!adjList[from].Contains(to))
            {
                adjList[from].Add(to);
                adjList[to].Add(from); // Undirected graph
            }
        }

        public static void RandomizeGraph(double connectionChance = 0.5)
        {
            // ensure every node has at least one connection
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    int index = row * size + col;

                    // generate random node connection
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

            /* ensure all nodes are connected to a single graph?
            bool SingleGraph = false;
            while (!SingleGraph) 
            {
                //DFS search

                Dictionary<int, bool> searchedIndexes = new Dictionary<int, bool>();
                int index = 0;

                Console.Write("testing\n");
                foreach (var neighbor in adjList[index])
                {
                    searchedIndexes
                    Console.Write($"{index},{neighbor}");
                }

                Console.Write("\n");




                if (SingleGraph)
                {
                    SingleGraph = true;
                }
                else
                {
                    SingleGraph = false;
                }

                SingleGraph = true;
            }
            */
        }

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