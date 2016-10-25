using System;

namespace SandS.Algorithm.Library.GraphNamespace
{
    [Flags]
    public enum GraphState
    {
        Default = 0,
        CanBeCycle = 1,
        CanBeLooped = 2,
        CanBeNonConnectivly = 4,
        IsBinary = 8,
    }
}