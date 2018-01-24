using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using System.Threading.Tasks;
using Lean.Classes;

namespace Lean
{
    public enum TypeOfOperation {Niezdefiniowane, Czekanie, Kontrola, ValueAdded,Transport }
    public class ElementaryOperation :PropertyChangedBase
    {
        public int OperationId { get; set; }
        public string OperationName { get; set; }
        private BindableCollection<ElemTime> elementaryOperationTimes { get; set; } = new BindableCollection<ElemTime>();
        public BindableCollection<ElemTime> ElementaryOperationTimes
        {
            get
            {
                return elementaryOperationTimes;
            }
            set
            {
                elementaryOperationTimes = value;
                NotifyOfPropertyChange(() => ElementaryOperationTimes);
                NotifyOfPropertyChange(() => MinTime);
                NotifyOfPropertyChange(() => MaxTime);
                NotifyOfPropertyChange(() => AvgTime);

            }
        } 
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
                avgTime = ElementaryOperationTimes.Select(x=>x.Time).Average();
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
                minTime = ElementaryOperationTimes.Select(x=>x.Time).Min();
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
                maxTime = ElementaryOperationTimes.Select(x=>x.Time).Max();
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
            ElementaryOperationTimes.Add(new ElemTime(0));
            ElementaryOperationTimes.Add(new ElemTime(1));
            ElementaryOperationTimes.Add(new ElemTime(2));
            ElementaryOperationTimes.Add(new ElemTime(3));
            ElementaryOperationTimes.Add(new ElemTime(4));
            ElementaryOperationTimes.Add(new ElemTime(5,10));
            ElementaryOperationTimes.Add(new ElemTime(6));
            ElementaryOperationTimes.Add(new ElemTime(7,4));
            ElementaryOperationTimes.Add(new ElemTime(8));
            ElementaryOperationTimes.Add(new ElemTime(9));
            MinTime = ElementaryOperationTimes.Select(x=>x.Time).Min();
            MaxTime = ElementaryOperationTimes.Select(x=>x.Time).Max();
            AvgTime = ElementaryOperationTimes.Select(x=>x.Time).Average();
            Stability = MaxTime - MinTime;
        }
    }
}
