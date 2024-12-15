namespace Parser
{ 

    using System;
    using System.Collections;
    using System.Text;

    public class Line
    {
        public Tuple<string, bool> Initialize(string line, int fileLineNumber)
        {
            return Parse(line, fileLineNumber);
        }

        private Tuple<string, bool> Parse(string line, int fileLineNumber)
        {
            if (Point != null || Combinations != null)
            {
                return new Tuple<string, bool>("", false);
            }

            var entries = line.Split(Token);
            if (entries.Length != LineSize)
            {
                return new Tuple<string, bool>(String.Format("Line with number {0} contains invalid number of characters", fileLineNumber), false);
            }

            if (!uint.TryParse(entries[LineNumber], out var lineNumber))
            {
                return new Tuple<string, bool>(String.Format("Line with number {0} failed reading", fileLineNumber), false);
            }

            if (!float.TryParse(entries[XCoord], out var x))
            {
                return new Tuple<string, bool>(String.Format("Line with number {0} failed reading X Coordinate", fileLineNumber), false);
            }

            if (!float.TryParse(entries[YCoord], out var y))
            {
                return new Tuple<string, bool>(String.Format("Line with number {0} failed reading Y Coordinate", fileLineNumber), false);
            }

            if (!float.TryParse(entries[ZCoord], out var z))
            {
                return new Tuple<string, bool>(String.Format("Line with number {0} failed reading Z Coordinate", fileLineNumber), false);
            }

            if (!uint.TryParse(entries[Combination], out var combination))
            {
                return new Tuple<string, bool>(String.Format("Line with number {0} failed reading combination", fileLineNumber), false);
            }

            CurrentLineNumber = lineNumber;
            Point = new Point(x, y, z);
            Combinations = new Combinations();

            return Combinations.InitializeCombination(combination, fileLineNumber);
        }
        public Combinations Combinations { get; private set; }
        public Point Point { get; private set; }

        public UInt32 CurrentLineNumber { get; private set; }

        // Globals used for line parsing
        private const int LineSize = 5;
        private const char Token = ';';
        private const ushort LineNumber = 0;
        private const ushort XCoord = 1;
        private const ushort YCoord = 2;
        private const ushort ZCoord = 3;
        private const ushort Combination = 4;
    }
}