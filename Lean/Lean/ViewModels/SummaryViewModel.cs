using Caliburn.Micro;
using Lean.Classes;
using Lean.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lean
{
    public class SummaryViewModel : Screen, IObserwator
    {
        private ShellViewModel shellVM { get; set; }
        public BindableCollection<CycleAnalyse> CycleAnalyses { get; set; } = new BindableCollection<CycleAnalyse>();
        public double SumWaitingTime { get; set; }
        public double SumAVTime { get; set; }

        private double ctTime;
        public double CTTime
        {
            get
            {
                return ctTime;
            }
            set
            {
                ctTime = CalculateCT();
                NotifyOfPropertyChange(() => CTTime);
            }
        }
        private double CalculateCT()
        {
            double CT=0;
            foreach (var item in CycleAnalyses)
            {
                CT += item.AvarageCycle;
            }
            return CT;
        }
        public SummaryViewModel(ShellViewModel svm)
        {
            shellVM = svm;
        }
        public void Aktualizuj()
        {
            CycleAnalyses = shellVM.CurrentOperation.CycleAnalyses;
            NotifyOfPropertyChange(() => CycleAnalyses);
            SumWaitingTime = CycleAnalyses.Where(x => x.OperationType == TypeOfOperation.Czekanie).Sum(z => z.AvarageCycle);
            
        }
    }
}
