using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class AutocadLineGenerator
    {
        AutocadLineGenerator()
        {
            _lineBuilder = new LineBuilder();
            _lineCombiner = new LineCombiner();
        }

        public List<List<Point>> getLines(string filePath, Combinations combinationsToExclude)
        {
            var lines = _lineBuilder.ExtractLinesFromFile(filePath, combinationsToExclude);
            return _lineCombiner.CombineLines(lines);
        }

        LineBuilder _lineBuilder;
        LineCombiner _lineCombiner;
    }
}
