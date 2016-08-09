namespace SandS.Algorithm.Library.GeneratorNamespace
{
    internal class ISBN10
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int Control { get; set; }

        public override string ToString()
        {
            return $"ISBN {this.A}-{this.B}-{this.C}-{(this.Control == 10 ? "X" : this.Control.ToString())}";
        }
    }
}