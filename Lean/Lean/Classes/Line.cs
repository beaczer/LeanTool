using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Lean.Interface;

namespace Lean.Classes
{
    public class Line:PropertyChangedBase,ILine
    {
        public string LineName { get; private set; }
        public BindableCollection<IOperation> ListOfOperation { get; set; } = new BindableCollection<IOperation>();
        
        
        public Line(string name)
        {
            LineName = name;
        }
    }
}
