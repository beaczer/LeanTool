using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lean.Classes
{
    public class BalansData:IBalansData
    {
        public CycleAnalyse CycleAnalys { get; set; }
        public double AVGTime { get; set; }
        public int OperatorNumber { get; set; }
        public int Order { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public BalansData(CycleAnalyse ca, double avgTime,int operatorNumber, int order,string name,int id)
        {
            CycleAnalys = ca;
            AVGTime = avgTime;
            OperatorNumber = operatorNumber;
            Order = order;
            Name = name;
            Id = id;
        }

    }
}
