using SandS.Algorithm.CommonNamespace;
using SandS.Algorithm.Library.PositionNamespace;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SandS.Algorithm.Library.Generator
{
    public static class A
    {
        public static bool TryGetValue(this LabyrinthCell[,] arr, int x, int y, out LabyrinthCell cell)
        {
            if (x >= 0 &&
                x < arr.GetLength(0) &&
                y >= 0 &&
                y < arr.GetLength(1))
            {
                cell = arr[x, y];
                return true;
            }

            cell = null;
            return false;
        }
    }

    public static class LabyrinthGeneratorStrategies
    {
        public static int L { get; set; }
        public static int R { get; set; }

        static LabyrinthGeneratorStrategies()
        {
            LabyrinthGeneratorStrategies.L = 20; // TODO rename
            LabyrinthGeneratorStrategies.R = 40;
        }

        public static Labyrinth Quick(Position size, bool removeTrash = true)
        {
            Labyrinth labyrinth = new Labyrinth(size);

            LabyrinthGeneratorStrategies.QuickFill(labyrinth);
            LabyrinthGeneratorStrategies.ResetBoundaries(size, labyrinth);

            if (removeTrash)
            {
                LabyrinthGeneratorStrategies.RemoveTrash(labyrinth);
            }

            return labyrinth;
        }

        private static void ResetBoundaries(Position size, Labyrinth labyrinth)
        {
            for (int i = 0; i < size.X; i++)
            {
                labyrinth.Cells[i, 0].Type = LabyrinthCellType.BorderLeft;
                labyrinth.Cells[i, size.Y - 1].Type = LabyrinthCellType.BorderRight;
            }

            for (int i = 0; i < size.Y; i++)
            {
                labyrinth.Cells[0, i].Type = LabyrinthCellType.BorderUp;
                labyrinth.Cells[size.X - 1, i].Type = LabyrinthCellType.BorderDown;
            }
        }

        private static void QuickFill(Labyrinth labyrinth)
        {
            foreach (var cell in labyrinth.Cells)
            {
                int rndValue = CommonValues.Random.Next(0, 100);

                if (rndValue < LabyrinthGeneratorStrategies.L)
                {
                    cell.Type = LabyrinthCellType.BorderDown;
                    continue;
                    ;
                }

                if (rndValue < LabyrinthGeneratorStrategies.R)
                {
                    cell.Type = LabyrinthCellType.BorderLeft;
                    continue;
                }

                cell.Type = LabyrinthCellType.Free;
            }
        }

        public static Labyrinth DFS(Position size, bool removeTrash = true)
        {
            Labyrinth labyrinth = new Labyrinth(size);

            foreach (var cell in labyrinth.Cells)
            {
                cell.Type = LabyrinthCellType.BorderUp |
                            LabyrinthCellType.BorderRight |
                            LabyrinthCellType.BorderDown |
                            LabyrinthCellType.BorderLeft;
            }

            Position head = new Position(labyrinth.Cells.GetLength(0) / 2,
                                            labyrinth.Cells.GetLength(1) / 2);

            bool[,] visitedCells = new bool[size.X, size.Y];
            visitedCells[head.X, head.Y] = true;

            bool hasUnvisitedCells = true;

            Stack<LabyrinthCell> cellStack = new Stack<LabyrinthCell>(labyrinth.Cells.Length);

            while (hasUnvisitedCells)
            {
                bool hasUnvisitedNeighbours = labyrinth.GetNeighborsFor(labyrinth.Cells[head.X, head.Y])
                                                            .Any(c => visitedCells[c.Position.X, c.Position.Y] = true);

                if (hasUnvisitedNeighbours)
                {
                    cellStack.Push(labyrinth.Cells[head.X, head.Y]);



                    List<LabyrinthCell> neighbours = labyrinth.GetNeighborsFor(labyrinth.Cells[head.X, head.Y]).ToList();

                    int randomValue = CommonValues.Random.Next(0, neighbours.Count);

                    LabyrinthCell nextCell = neighbours[randomValue];

                    if ()
                }
                else
                {
                    if (cellStack.Count != 0)
                    {
                        LabyrinthCell cell = cellStack.Pop();
                        head.X = cell.Position.X;
                        head.Y = cell.Position.Y;
                    }
                    else
                    {
                        for (int i = 0; i < size.X; i++)
                        {
                            for (int j = 0; j < size.Y; j++)
                            {
                                if (visitedCells[i, j] == false)
                                {
                                    visitedCells[i, j] = true;

                                    head.X = i;
                                    head.Y = j;

                                    goto loopexit;
                                }
                            }
                        }

                        loopexit:
                        ;
                    }
                }

                hasUnvisitedCells = visitedCells.Cast<bool>().Any(visitedCell => visitedCell == true);
            }

            if (removeTrash)
            {
                LabyrinthGeneratorStrategies.RemoveTrash(labyrinth);
            }

            return labyrinth;
        }

        public static void RemoveTrash(Labyrinth labyrinth)
        {
            for (int i = 0; i < labyrinth.Cells.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.Cells.GetLength(1); j++)
                {
                    var cell = labyrinth.Cells[i, j];

                    IEnumerable<LabyrinthCell> neighbors = labyrinth.GetNeighborsFor(cell);

                    bool isBounded = neighbors.Any(n => n.Type != LabyrinthCellType.Free);

                    if (!isBounded)
                    {
                        cell.Type = LabyrinthCellType.Free;
                    }
                }
            }
        }
    }
}