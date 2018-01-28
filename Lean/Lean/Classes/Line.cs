using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Lean.Classes
{
    public class Line
    {
        public string LineName { get; set; }
        public BindableCollection<Operation> ListOfOperation { get; set; } = new BindableCollection<Operation>();
        public Line(string name)
        {
            LineName = name;
        }
    }
}
