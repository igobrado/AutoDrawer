namespace Parser;

using System;
using System.Collections;

public class Combinations
{
    public Combinations(UInt32 combination)
    {
    }

    public bool initializeCombination(UInt32 combination)
    {
        constructCombinationList(combination);

        return _combinations != null && _combinations.Count != 0;
    }

    public List<Combination> Value
    {
        get { return _combinations; }
    }

    void constructCombinationList(UInt32 combination)
    {
        if (combination == 0)
        {
            return;
        }
        _combinations = new List<Combination>();


        while (combination > 0)
        {
            uint mod = combination % 10;
            _combinations.Add(new Combination(mod));

            combination = combination / 10;
        }
        
    }
    
    private List<Combination> _combinations;
}