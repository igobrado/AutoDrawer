namespace Parser;

public class Combinations
{
    public Combinations(UInt32 combination)
    {
        initializeCombination(combination);    
    }
    
    public List<Combination> Value
    {
        get { return _combinations; }
    }

    void initializeCombination(UInt32 combination)
    {
        
    }
    
    private List<Combination> _combinations;
}