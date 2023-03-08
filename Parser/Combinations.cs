namespace Parser;

using System;
using System.Collections;

public class Combinations
{
    public Tuple<string, bool> InitializeCombination(UInt32 combination, int fileLineNumber)
    {
        return ConstructCombinationList(combination, fileLineNumber);
    }

    public List<Combination> Value
    {
        get { return _combinations; }
    }

    Tuple<string, bool> ConstructCombinationList(UInt32 combination, int fileLineNumber)
    {
        if (combination == 0)
        {
            return new Tuple<string, bool>(String.Format("Line with number {0} has invalid combination number!", fileLineNumber), false);
        }

        if (HasOddNumberOfDigits(combination))
        {
            return new Tuple<string, bool>(String.Format("Line with number {0}, combination has invalid number of digits!", fileLineNumber), false);
        }

        _combinations = new List<Combination>();
        while (combination > 0)
        {
            uint mod = combination % 100;
            _combinations.Add(new Combination(mod));

            combination = combination / 100;
        }

        _combinations.Reverse();
        return new Tuple<string, bool>("", true);
    }

    bool HasOddNumberOfDigits(uint number)
    {
        int n = 0;
        while (number > 0)
        {
            number = number / 10;
            ++n;
        }

        if (n % 2 != 0)
        {
            return true;
        }

        return false;
    }
    private List<Combination> _combinations;
}