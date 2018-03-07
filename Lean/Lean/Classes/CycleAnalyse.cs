using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Lean.Classes
{
    public class CycleAnalyse:PropertyChangedBase
    {
        public TypeOfOperation OperationType {
            get;
            set;
        }
        
        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }
        public BindableCollection<double> list { get; set; } = new BindableCollection<double>();
        private double avarageCycle;
        public double AvarageCycle
        {
            get
            { return avarageCycle; }
            set
            {
                avarageCycle =Math.Round(value,2);
                NotifyOfPropertyChange(() => AvarageCycle);
            }
        }
        private double minCycle;
        public double MinCycle
        {
            get
            { return minCycle; }
            set
            {
                minCycle = Math.Round(value, 2);
                NotifyOfPropertyChange(() => MinCycle);
            }
        }
        private double maxCycle;
        public double MaxCycle
        {
            get
            { return maxCycle; }
            set
            {
                maxCycle = Math.Round(value, 2);
                NotifyOfPropertyChange(() => MaxCycle);
            }
        }
        public CycleAnalyse(int id)
        {
            Id = id;
            Name = name;
            list.CollectionChanged += CollectionChange;
        }

        private void CollectionChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            AvarageCycle = list.Average();
            MinCycle = list.Min();
            MaxCycle = list.Max();
        }
    }
}
