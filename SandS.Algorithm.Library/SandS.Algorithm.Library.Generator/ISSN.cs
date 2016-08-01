using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandS.Algorithm.Library.Generator
{
    internal class ISSN
    {
        public int A { get; set; }
        public int B { get; set; }
        public int Control { get; set; }

        public override string ToString()
        {
            return $"ISSN {this.A}-{this.B}{(this.Control == 10 ? "X" : this.Control.ToString())}";
        }
    }
}
