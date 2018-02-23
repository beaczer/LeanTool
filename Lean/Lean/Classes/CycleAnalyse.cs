using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Lean.Classes
{
    public class CycleAnalyse:PropertyChangedBase
    {
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
        public double AvarageCycle { get; private set; }
        public CycleAnalyse(int id)
        {
            Id = id;
            Name = name;
        }
        public void SetCycle()
        {
         
         
        }

    }
}
