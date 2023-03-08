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
            if (filePath == null || File.Exists(filePath))
            {
                return null;
            }

            return _lineCombiner.CombineLines(_lineBuilder.ExtractLinesFromFile(filePath, combinationsToExclude));
        }

        LineBuilder _lineBuilder;
        LineCombiner _lineCombiner;
    }
}
