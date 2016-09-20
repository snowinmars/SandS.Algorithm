using SandS.Algorithm.Library.PositionNamespace;

namespace SandS.Algorithm.Library.Generator
{
    public class LabyrinthCell
    {
        public LabyrinthCell(Position position)
        {
            this.Position = position;
        }

        public Position Position { get; set; }

        public LabyrinthCellType Type { get; set; }
    }
}