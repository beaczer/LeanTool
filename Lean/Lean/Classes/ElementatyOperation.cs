using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using System.Threading.Tasks;

namespace Lean
{
    public enum TypeOfOperation {Niezdefiniowane, Czekanie, Kontrola, ValueAdded,Transport }
    public class ElementaryOperation :PropertyChangedBase
    {
        public int OperationId { get; set; }
        public string OperationName { get; set; }
        public List<double> ElementaryOperationTimes { get; set; } = new List<double>();
        public TypeOfOperation ElementaryOperationType { get; set; }
        private double avgTime;
        public double AvgTime
        {
            get
            {
                return avgTime;
            }
            private set
            {
                avgTime = ElementaryOperationTimes.Average();
                NotifyOfPropertyChange(() => AvgTime);
            }
        }
        private double minTime;
        public double MinTime
        {
            get
            {
                return minTime;
            }
            private set
            {
                minTime = ElementaryOperationTimes.Min();
                NotifyOfPropertyChange(() => MinTime);
            }
        }
        private double maxTime;
        public double MaxTime
        {
            get
            {
                return maxTime;
            }
            private set
            {
                maxTime = ElementaryOperationTimes.Max();
                NotifyOfPropertyChange(() => MaxTime);
            }
        }
        private double stability;
        public double Stability
        {
            get
            {
                return stability;
            }
            set
            {
                stability = MaxTime - MinTime;
                NotifyOfPropertyChange(() => Stability);
            }
        }
        
        public ElementaryOperation()
        {
            ElementaryOperationTimes.Add(0);
            ElementaryOperationTimes.Add(0);
            ElementaryOperationTimes.Add(0);
            ElementaryOperationTimes.Add(0);
            ElementaryOperationTimes.Add(0);
            ElementaryOperationTimes.Add(0);
            ElementaryOperationTimes.Add(0);
            ElementaryOperationTimes.Add(0);
            ElementaryOperationTimes.Add(0);
            ElementaryOperationTimes.Add(0);
        }
    }
}
