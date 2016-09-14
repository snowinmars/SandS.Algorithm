using SandS.Algorithm.Library.EnumsNamespace;
using SandS.Algorithm.Library.PositionNamespace;
using System.Collections.Generic;

namespace SandS.Algorithm.Library.Generator
{
    public class Labyrinth
    {
        public Labyrinth(Position size)
        {
            this.Size = size;

            this.Cells = new LabyrinthCell[size.X, size.Y];

            for (int i = 0; i < size.X; i++)
            {
                for (int j = 0; j < size.Y; j++)
                {
                    this.Cells[i, j] = new LabyrinthCell(new Position(i, j));
                }
            }
        }

        public Position Size { get; set; }

        public LabyrinthCell[,] Cells { get; private set; }

        public IDictionary<Direction, LabyrinthCell> GetNeighborsFor(LabyrinthCell cell)
        {
            IDictionary<Direction, LabyrinthCell> neighbors = new Dictionary<Direction, LabyrinthCell>(4);

            if (cell.Position.X != 0)
            {
                neighbors.Add(Direction.Left, this.Cells[cell.Position.X - 1, cell.Position.Y]);
            }

            if (cell.Position.X != this.Cells.GetLength(0) - 1)
            {
                neighbors.Add(Direction.Right, this.Cells[cell.Position.X + 1, cell.Position.Y]);
            }

            if (cell.Position.Y != 0)
            {
                neighbors.Add(Direction.Up, this.Cells[cell.Position.X, cell.Position.Y - 1]);
            }

            if (cell.Position.Y != this.Cells.GetLength(1) - 1)
            {
                neighbors.Add(Direction.Down, this.Cells[cell.Position.X, cell.Position.Y + 1]);
            }

            return neighbors;
        }
    }
}