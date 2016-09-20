using System;

namespace SandS.Algorithm.Library.Generator
{
    [Flags]
    public enum LabyrinthCellType
    {
        Free = 0,
        BorderUp = 1,
        BorderRight = 2,
        BorderDown = 4,
        BorderLeft = 8,
        BorderDownSlash = 16,
        BorderUpSlash = 32,
    }
}