using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Parser
{
    public class LineCombiner
    {
        public List<List<Point>> CombineLines(List<Line> linesToCombine)
        {
            List<List<Point>> drawing = new List<List<Point>>();

            for (int i = 0; i < linesToCombine.Count; i++)
            {
                List<Point> line = new List<Point>();

                var combinations = linesToCombine[i].Combinations;
                if (combinations.IsEmpty())
                {
                    continue;
                }

                Point dot = linesToCombine[i].Point;
                var combinationToMark = combinations.Value.First();

                linesToCombine[i].Combinations.PopCombination(); // Mark the teritory
                line.Add(dot);

                for (int j = 0; j < linesToCombine.Count; ++j)
                {
                    var currentLine        = linesToCombine[j];
                    var currentCombination = linesToCombine[j].Combinations.Value.First();

                    if (currentCombination == combinationToMark)
                    {
                        // One more point that will be drawn
                        line.Add(currentLine.Point);

                        currentLine.Combinations.PopCombination(); // Mark the teritory;
                        if (currentLine.Combinations.IsNotEmptyAndShouldCloseLine())
                        {
                            // As combination states number 39 that means we should stop drawing this line
                            currentLine.Combinations.PopCombination(); // Mark the teritory;
                            break;
                        }
                    }
                }

                drawing.Add(line);
            }


            return drawing;
        }
    }
}
