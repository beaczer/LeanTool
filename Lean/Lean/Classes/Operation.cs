using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lean.Classes
{
    public class Operation
    {
        public int OperationId { get; private set; }
        public string OperationName { get; private set; }
        public List<Operation> listOfOperation {get;set;}
    }
}
