using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandS.Algorithm.Library.Menu
{
    public interface IBuilder<T>
    {
        T Build();
    }
}
