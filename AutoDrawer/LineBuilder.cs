using System.Collections.Generic;

namespace Parser
{
    public class LineBuilder
    {
        public List<Line> ExtractLinesFromFile(string filePath, Combinations combinationsToExclude)
        {
            List<Line> rv = new List<Line>();

            foreach (string line in System.IO.File.ReadLines(filePath))
            {
                int i = 0;
                Line l = new Line();
                var result = l.Initialize(line, i);
                var combinations = l.Combinations.Value;

                if (result.Item2)
                {
                    for (int j = 0; j < combinations.Count; ++j)
                    {
                        while (true)
                        {
                            var isInList = combinationsToExclude.Value.FindIndex(x => x.Value == combinations[i].Value);
                            if (isInList == -1)
                            {
                                break;
                            }

                            // See whether 39 is last number, if it is then remove it
                            if (isInList + 1 <= combinations.Count)
                            {
                                if (combinations[isInList + 1].Value == 39)
                                {
                                    combinations.RemoveAt(isInList);
                                    combinations.RemoveAt(isInList + 1);
                                }
                            }

                        }

                        rv.Add(l);
                    }
                }
                else
                {
                    // log error
                }
                ++i;
            }

            return rv;
        }
    }
}
