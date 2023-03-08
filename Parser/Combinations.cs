namespace Parser;

using System;
using System.Collections;

public class Combinations
{
    public bool InitializeCombination(UInt32 combination)
    {
        ConstructCombinationList(combination);

        return _combinations != null && _combinations.Count != 0;
    }

    public List<Combination> Value
    {
        get { return _combinations; }
    }

    void ConstructCombinationList(UInt32 combination)
    {
        if (combination == 0)
        {
            return;
        }

        int n = 0;
        var c = combination;
        while(c > 0)
        {
            c = c / 10;
            ++n;
        }

        if (n % 2 != 0)
        {
            return;
        }

        _combinations = new List<Combination>();

        while (combination > 0)
        {
            uint mod = combination % 100;
            _combinations.Add(new Combination(mod));

            combination = combination / 100;
        }

        _combinations.Reverse();
    }
    
    private List<Combination> _combinations;
}