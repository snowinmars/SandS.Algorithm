using SandS.Algorithm.Library.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using SandS.Algorithm.Library.PositionNamespace;

namespace ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                const int x = 10;
                const int y = 10;

                LabyrinthGeneratorStrategies.L = 40;
                LabyrinthGeneratorStrategies.R = 60;

                Labyrinth labyrinth = LabyrinthGeneratorStrategies.DFS(new Position(x, y));

                int count = 0;

                foreach (var cell in labyrinth.Cells)
                {
                    string c;

                    switch (cell.Type)
                    {
                        case LabyrinthCellType.Free:
                            c = " ";
                            break;
                        case LabyrinthCellType.BorderUp:
                            c = "_";
                            break;
                        case LabyrinthCellType.BorderRight:
                        case LabyrinthCellType.BorderLeft:
                            c = "|";
                            break;
                        case LabyrinthCellType.BorderDown:
                            c = "_";
                            break;
                        case LabyrinthCellType.BorderDownSlash:
                            c = "/";
                            break;
                        case LabyrinthCellType.BorderUpSlash:
                            c = "\\";
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    Console.Write(c);

                    count++;

                    if (count == y)
                    {
                        Console.WriteLine();
                        count = 0;
                    }
                }

                Console.ReadKey();
            }
        }
    }
}