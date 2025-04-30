using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// interface for identifying events within room objects
    /// </summary>
    public interface IEvent
    {
        string Type(); 

        int Stat();
    }
}  