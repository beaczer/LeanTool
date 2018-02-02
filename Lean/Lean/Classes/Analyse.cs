using Lean.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Lean.Classes
{
    public class Analyse:IAnalyse
    {
        private DateTime startTime;
        public DateTime StartTime { get; set; }

        private DateTime stopTime;
        public DateTime StopTime { get; set; }

        public void  CalculateDifference(DateTime start, DateTime stop)
        {


        }
    }
}
