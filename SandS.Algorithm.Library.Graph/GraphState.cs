using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandS.Algorithm.Library.Graph
{
    [Flags]
    public enum GraphState
    {
        Default = 0,
        CanBeCycle = 1,
        CanBeLooped = 2,
        CanBeNonConnectivly = 4,
    }
}
