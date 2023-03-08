namespace Parser;
using System.Collections;

public class Line
{
    public bool Initialize(string line)
    {
        return Parse(line);
    }

    private bool Parse(string line)
    {
        if (Point != null || Combinations != null)
        {
            return false;
        }

        var entries = line.Split(Token);
        if (entries.Length != LineSize)
        {
            return false;
        }

        if (!uint.TryParse(entries[LineNumber], out var lineNumber))
        {
            return false;
        }

        if (!float.TryParse(entries[XCoord], out var x))
        {
            return false;
        }

        if (!float.TryParse(entries[YCoord], out var y))
        {
            return false;
        }

        if (!float.TryParse(entries[ZCoord], out var z))
        {
            return false;
        }

        if (!uint.TryParse(entries[Combination], out var combination))
        {
            return false;
        }

        CurrentLineNumber = lineNumber;
        Point = new Point(x, y, z);
        Combinations = new Combinations(combination);

        return Combinations.initializeCombination(combination);
    }
    public Combinations Combinations { get; private set; } = null!;
    public Point Point { get; private set; } = null!;

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