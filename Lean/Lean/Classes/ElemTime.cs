using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lean.Classes
{
    public class ElemTime
    {
        public int ElemId { get; set; }
        public double Time { get; set; }
        
        public ElemTime(int id)
        {
            ElemId = id;
            Time = 0;
        }
        public ElemTime(int id,double time)
        {
            ElemId = id;
            Time = time;
        }
    }
}
