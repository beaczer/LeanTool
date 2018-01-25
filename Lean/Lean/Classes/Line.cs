using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lean.Classes
{
    public class Line
    {
        public string LineName { get; set; }
        public List<Operation> ListOfOperation { get; set; } = new List<Operation>();
        public Line(string name)
        {
            LineName = name;
        }
    }
}
