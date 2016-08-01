using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandS.Algorithm.Library.Enums
{
    [Flags]
    public enum InputKeyPressType
    {
        OnUp = 0,
        OnDown = 1,
    }

    [Flags]
    public enum MouseButton
    {
        Left = 0,
        Middle = 1,
        Right = 2,
    }

    [Flags]
    public enum Commands
    {
        Wait = 0,
        MoveUp = 1,
        MoveDown = 2,
        MoveLeft = 4,
        MoveRight = 8,
    }
}
