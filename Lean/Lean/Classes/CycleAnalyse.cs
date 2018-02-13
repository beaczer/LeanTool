using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Lean.Classes
{
    public class CycleAnalyse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BindableCollection<double> list { get; set; } = new BindableCollection<double>();
        public double AvarageCycle { get; private set; }
        public CycleAnalyse(int id)
        {
            Id = id;
            list.Add(1);
            list.Add(1);
            list.Add(1);
            list.Add(100);
            
        }
        public void SetCycle()
        {
         
         
        }

    }
}
