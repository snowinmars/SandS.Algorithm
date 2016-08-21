using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandS.Algorithm.Library.Generator
{
    public enum Form
    {
        Round,
        Circle,
        Square,
    }

    public class Glade
    {
        public Form Form{ get; set; }
        public int Size { get; set; }
    }
}
