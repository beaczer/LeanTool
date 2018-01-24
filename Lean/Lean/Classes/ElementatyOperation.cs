using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lean
{
    public class ElementaryOperation
    {
        public int OperationId { get; private set; }
        public string OperationName { get; set; }
        public List<double> ElementaryOperationTimes { get; set; } = new List<double>();
        public double AvgTime { get; private set; }
        public double MinTime { get; private set; }
        public double MaxTime { get; private set; }
        public double ModTime { get; private set; }
        public double Stability { get; private set; }
    }
}
