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
        private string operationName;
        public string OperationName
        {
            get
            {
                return operationName;
            }
            set
            {
                operationName = value;
                NotifyOfPropertyChange(() => OperationName);
            }
        }
        
        

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
             set
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
             set
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
            set
            {
                maxTime = ElementaryOperationTimes.Select(x=>x.Time).Max();
                NotifyOfPropertyChange(() => MaxTime);
            }
        }
        private double freq;
        public double Freq
        {
            get
            {
                return freq;
            }
            set
            {
                freq = value;
                NotifyOfPropertyChange(() => Freq);
            }
        }
        private int human;
        public int Human
        {
            get
            {
                return human;
            }
            set
            {
                human = value;
                NotifyOfPropertyChange(() => Human);
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
            ElementaryOperationTimes.Add(new ElemTime(5));
            ElementaryOperationTimes.Add(new ElemTime(6));
            ElementaryOperationTimes.Add(new ElemTime(7));
            ElementaryOperationTimes.Add(new ElemTime(8));
            ElementaryOperationTimes.Add(new ElemTime(9));
            MinTime = ElementaryOperationTimes.Select(x=>x.Time).Min();
            MaxTime = ElementaryOperationTimes.Select(x=>x.Time).Max();
            AvgTime = ElementaryOperationTimes.Select(x=>x.Time).Average();
            Stability = MaxTime - MinTime;
        }
    }
    [Serializable]
    public class ElementaryOperationToSave
    {
        public int OperationId;
        public string OperationName;
        public BindableCollection<ElemTime> ElementaryOperationTimes;
        public TypeOfOperation ElementaryOperationType;
        public double AvgTime;
        public double MinTime;
        public double MaxTime;
        public double Freq;
        public double Stability;

        public ElementaryOperationToSave(int operId, string operName, BindableCollection<ElemTime> elem,
                TypeOfOperation Eleme, double avg, double min, double max, double freq, double stab)
        {
            this.OperationId = operId;
            this.OperationName = operName;
            this.ElementaryOperationTimes = elem;
            this.ElementaryOperationType = Eleme;
            AvgTime = avg;
            MinTime = min;
            MaxTime = max;
            Freq = freq;
            Stability = stab;
        }
    }
}
