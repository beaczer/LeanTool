using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lean.Classes
{
    public class Operation
    {
        public int LineId { get; private set; }
        public string LineName { get; private set; }
        public List<ElementaryOperation> listOfOperation {get;set;}
    }
}
