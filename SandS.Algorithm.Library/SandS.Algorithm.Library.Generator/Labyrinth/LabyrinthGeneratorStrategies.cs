using SandS.Algorithm.CommonNamespace;
using SandS.Algorithm.Library.EnumsNamespace;
using SandS.Algorithm.Library.PositionNamespace;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
            Contract.Requires<ArgumentNullException>(size != null, "Size cannot be null");
            Contract.Requires<InvalidOperationException>(size.X > 0, "Size must be positive");
            Contract.Requires<InvalidOperationException>(size.Y > 0, "Size must be positive");

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
            Contract.Requires<ArgumentNullException>(size != null, "Size cannot be null");
            Contract.Requires<InvalidOperationException>(size.X > 0, "Size must be positive");
            Contract.Requires<InvalidOperationException>(size.Y > 0, "Size must be positive");

            Contract.Requires<ArgumentNullException>(labyrinth != null, "Labyrinth cannot be null");
            Contract.Requires<InvalidOperationException>(labyrinth.Size.X > 0, "Labyrinth size must be positive");
            Contract.Requires<InvalidOperationException>(labyrinth.Size.Y > 0, "Labyrinth size must be positive");

            for (int i = 0; i < size.X; i++)
            {
                labyrinth.Cells[i, 0].Type = LabyrinthCellType.BorderUp;
                labyrinth.Cells[i, size.Y - 1].Type = LabyrinthCellType.BorderDown;
            }

            for (int i = 0; i < size.Y; i++)
            {
                labyrinth.Cells[0, i].Type = LabyrinthCellType.BorderLeft;
                labyrinth.Cells[size.X - 1, i].Type = LabyrinthCellType.BorderRight;
            }
        }

        private static void QuickFill(Labyrinth labyrinth)
        {
            Contract.Requires<ArgumentNullException>(labyrinth != null, "Labyrinth cannot be null");
            Contract.Requires<InvalidOperationException>(labyrinth.Size.X > 0, "Labyrinth size must be positive");
            Contract.Requires<InvalidOperationException>(labyrinth.Size.Y > 0, "Labyrinth size must be positive");

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
            Contract.Requires<ArgumentNullException>(size != null, "Size cannot be null");
            Contract.Requires<InvalidOperationException>(size.X > 0, "Size must be positive");
            Contract.Requires<InvalidOperationException>(size.Y > 0, "Size must be positive");

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
                IDictionary<Direction, LabyrinthCell> neighbours = labyrinth.GetNeighborsFor(labyrinth.Cells[head.X, head.Y])
                                                                                .Where(c => false == visitedCells[c.Value.Position.X, c.Value.Position.Y])
                                                                                .ToDictionary(c => c.Key, c => c.Value);

                if (neighbours.Count != 0)
                {
                    cellStack.Push(labyrinth.Cells[head.X, head.Y]);

                    if (neighbours.Count != 0)
                    {
                        int randomValue = CommonValues.Random.Next(0, neighbours.Count);

                        var keys = neighbours.Keys;

                        LabyrinthCell nextCell = neighbours[keys.ElementAt(randomValue)];

                        switch (keys.ElementAt(randomValue))
                        {
                        case Direction.Wait:
                            break;

                        case Direction.Up:
                            nextCell.Type -= LabyrinthCellType.BorderDown;
                            labyrinth.Cells[head.X, head.Y].Type -= LabyrinthCellType.BorderUp;
                            break;

                        case Direction.Right:
                            nextCell.Type -= LabyrinthCellType.BorderLeft;
                            labyrinth.Cells[head.X, head.Y].Type -= LabyrinthCellType.BorderRight;
                            break;

                        case Direction.Down:
                            nextCell.Type -= LabyrinthCellType.BorderUp;
                            labyrinth.Cells[head.X, head.Y].Type -= LabyrinthCellType.BorderDown;
                            break;

                        case Direction.Left:
                            nextCell.Type -= LabyrinthCellType.BorderRight;
                            labyrinth.Cells[head.X, head.Y].Type -= LabyrinthCellType.BorderLeft;
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                        }

                        head.X = nextCell.Position.X;
                        head.Y = nextCell.Position.Y;
                        visitedCells[nextCell.Position.X, nextCell.Position.Y] = true;
                    }
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

                hasUnvisitedCells = visitedCells.Cast<bool>().Any(visitedCell => false == visitedCell);
            }

            if (removeTrash)
            {
                LabyrinthGeneratorStrategies.RemoveTrash(labyrinth);
            }

            return labyrinth;
        }

        public static void MakeGlades(Labyrinth labyrinth, Glade glade, int num)
        {
            Contract.Requires<ArgumentNullException>(labyrinth != null, "Labyrinth cannot be null");
            Contract.Requires<InvalidOperationException>(labyrinth.Size.X > 0, "Labyrinth size must be positive");
            Contract.Requires<InvalidOperationException>(labyrinth.Size.Y > 0, "Labyrinth size must be positive");

            Contract.Requires<ArgumentNullException>(glade != null, "Glade cannot be null");
            Contract.Requires<InvalidOperationException>(glade.Size > 0, "Glade size must be positive");

            for (int i = 0; i < num; i++)
            {
                MakeGlade(labyrinth, glade);
            }
        }

        public static void MakeGlade(Labyrinth labyrinth, Glade glade)
        {
            Contract.Requires<ArgumentNullException>(labyrinth != null, "Labyrinth cannot be null");
            Contract.Requires<InvalidOperationException>(labyrinth.Size.X > 0, "Labyrinth size must be positive");
            Contract.Requires<InvalidOperationException>(labyrinth.Size.Y > 0, "Labyrinth size must be positive");

            Contract.Requires<ArgumentNullException>(glade != null, "Glade cannot be null");
            Contract.Requires<InvalidOperationException>(glade.Size > 0, "Glade size must be positive");

            int x = CommonValues.Random.Next(glade.Size, labyrinth.Cells.GetLength(0) - glade.Size);
            int y = CommonValues.Random.Next(glade.Size, labyrinth.Cells.GetLength(1) - glade.Size);

            Position randomPlace = new Position(x, y);

            switch (glade.Form)
            {
            case Form.Ring:
                for (int i = randomPlace.X - glade.Size; i < randomPlace.X + glade.Size; i++)
                {
                    for (int j = randomPlace.Y - glade.Size; j < randomPlace.Y + glade.Size; j++)
                    {
                        int dx = Math.Abs(labyrinth.Cells[i, j].Position.X - randomPlace.X);
                        int dy = Math.Abs(labyrinth.Cells[i, j].Position.Y - randomPlace.Y);

                        if (Math.Round(Math.Sqrt(dx * dx + dy * dy)) == glade.Size)
                        {
                            labyrinth.Cells[i, j].Type = LabyrinthCellType.Free;
                        }
                    }
                }
                break;

            case Form.Circle:
                for (int i = randomPlace.X - glade.Size; i < randomPlace.X + glade.Size; i++)
                {
                    for (int j = randomPlace.Y - glade.Size; j < randomPlace.Y + glade.Size; j++)
                    {
                        int dx = Math.Abs(labyrinth.Cells[i, j].Position.X - randomPlace.X);
                        int dy = Math.Abs(labyrinth.Cells[i, j].Position.Y - randomPlace.Y);

                        if (Math.Sqrt(dx * dx + dy * dy) < glade.Size)
                        {
                            labyrinth.Cells[i, j].Type = LabyrinthCellType.Free;
                        }
                    }
                }
                break;

            case Form.Square:
                for (int i = randomPlace.X - glade.Size; i < randomPlace.X + glade.Size; i++)
                {
                    for (int j = randomPlace.Y - glade.Size; j < randomPlace.Y + glade.Size; j++)
                    {
                        labyrinth.Cells[i, j].Type = LabyrinthCellType.Free;
                    }
                }
                break;

            default:
                break;
            }
        }

        public static void RemoveTrash(Labyrinth labyrinth)
        {
            Contract.Requires<ArgumentNullException>(labyrinth != null, "Labyrinth cannot be null");
            Contract.Requires<InvalidOperationException>(labyrinth.Size.X > 0, "Labyrinth size must be positive");
            Contract.Requires<InvalidOperationException>(labyrinth.Size.Y > 0, "Labyrinth size must be positive");

            for (int i = 0; i < labyrinth.Cells.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.Cells.GetLength(1); j++)
                {
                    var cell = labyrinth.Cells[i, j];

                    IDictionary<Direction, LabyrinthCell> neighbors = labyrinth.GetNeighborsFor(cell);

                    bool isBounded = neighbors.Any(n => n.Value.Type != LabyrinthCellType.Free);

                    if (!isBounded)
                    {
                        cell.Type = LabyrinthCellType.Free;
                    }
                }
            }
        }
    }
}