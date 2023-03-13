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
                    if (linesToCombine[j].Combinations.IsEmpty())
                    {
                        continue;
                    }

                    var currentLine        = linesToCombine[j];
                    var index = linesToCombine[j].Combinations.HasCombination(combinationToMark.Value);

                    if (index != -1) // combination was found
                    {
                        // One more point that will be drawn
                        line.Add(currentLine.Point);
                        bool shouldRemove = currentLine.Combinations.IsClosing(index + 1);
                        if (shouldRemove)
                        {
                            // First we remove 39 then we remove normal one
                            currentLine.Combinations.RemoveAt(index + 1); // Mark the teritory;
                            // As combination states number 39 that means we should stop drawing this line
                            currentLine.Combinations.RemoveAt(index);
                            break;
                        }

                        currentLine.Combinations.RemoveAt(index);
                    }
                }

                drawing.Add(line);
            }


            return drawing;
        }
    }
}
