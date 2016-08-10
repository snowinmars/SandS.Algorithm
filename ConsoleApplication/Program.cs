using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication
{
    internal class Program
    {
        private static Random rand = new Random();

        private static void Main(string[] args)
        {
            int capacity = 10;
            int[] array = new int[capacity];

            Program.SetWithRandomElements(array);

            foreach (int item in array.OrderBy(x => x))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"max: {array.Max()}");
            Console.WriteLine($"min: {array.Min()}");
        }

        private static void SetWithRandomElements(IList<int> array)
        {
            for (int i = 0; i < array.Count; i++)
            {
                array[i] = Program.rand.Next(-100, 100);
                Console.WriteLine(array[i]);
            }
        }
    }
}