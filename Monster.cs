﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// summary
    /// </summary>
    public class Monster : Event
    {
        /// <summary>
        /// summary
        /// </summary>
        public Monster()
        {
            Console.WriteLine("Monster created");
        }

        /// <summary>
        /// summary
        /// </summary>
        public void GetEvent()
        {
            Console.WriteLine("Getting Monster");
        }

        /// <summary>
        /// summary
        /// </summary> 
        public void GetEventStats()
        {
            Console.WriteLine("Getting Monster Stats");
        }
    }
}