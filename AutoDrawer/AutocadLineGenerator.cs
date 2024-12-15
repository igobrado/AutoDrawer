using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZwSoft.ZwCAD.Runtime;
using ZwSoft.ZwCAD.ApplicationServices;
using Parser;


[assembly: CommandClass(typeof(MyTestPlugin.Commands))]

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

        [CommandMethod("HelloWorld")]
        public void HelloWorld()
        {
            Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("\nHello, World!");
        }
    }

}

namespace MyTestPlugin
{
    public class Commands
    {
        [CommandMethod("HelloWorld")]
        public void HelloWorld()
        {
            Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("\nHello, World!");
        }
    }
}