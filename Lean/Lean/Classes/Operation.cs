using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Lean.Classes
{
    public class Operation
    {
        public int OperationId { get; private set; }
        public string OperationName { get; private set; }
        public BindableCollection<Operation> ListOfOperation { get; set; } = new BindableCollection<Operation>();
        public Operation(string name)
        {
            OperationName = name;
        }
    }
}
