namespace Parser 
{ 

    using System;
    using System.Collections;

    public class Combination
    {
        public Combination(UInt32 combination)
        {
            _value = combination;
        }

        public UInt32 Value => _value;
        private readonly UInt32 _value;
    }   
}