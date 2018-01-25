using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lean.Classes
{
    public class ElemTime:Screen
    {

        public int ElemId { get; set; }
        private double time;
        public double Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
                NotifyOfPropertyChange(() => Time);
            }
        }
        
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
