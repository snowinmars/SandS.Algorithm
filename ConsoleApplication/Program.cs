using System;
using System.Collections.Generic;
using System.Linq;
using SandS.Algorithm.Extensions.EventHandlerNamespace;

namespace ConsoleApplication
{
    internal class Program
    {
        public static EventHandler handler;

        private static void Main(string[] args)
        {
            EventHandler h = handler.Clone<int>();
        }
    }
}