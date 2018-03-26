using Caliburn.Micro;
using Lean.Classes;
using Lean.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lean.ViewModels
{
    public class ChartElement
    {
        public string Category { get; set; }
        public double Count { get; set; }

        public ChartElement(string cat, double time)
        {
            Category = cat;
            Count = time;
        }
    }
    public class BalansViewModel : Screen, IObserwator
    {
        public BindableCollection<IBalansData> BalansDatas { get; set; } = new BindableCollection<IBalansData>();
        public BindableCollection<CycleAnalyse> ElementaryOperations { get; set; } = new BindableCollection<CycleAnalyse>();
        private ShellViewModel shellVM { get; set; }
        private ILine currentLine;
        public ILine CurrentLine
        {
            get
            {
                return currentLine;
            }
            set
            {
                currentLine = value;
                NotifyOfPropertyChange(() => CurrentLine);
            }
        }

        public void Aktualizuj()
        {
            CurrentLine = shellVM.CurrentLine;
            //ElementaryOperations = new BindableCollection<CycleAnalyse>();
            
            int count = 1;
            int ord = 1;
            if (CurrentLine != null)
            {
                foreach (var item in CurrentLine.ListOfOperation)
                {
                    foreach (var item2 in item.CycleAnalyses)
                    {
                        BalansDatas.Add(new BalansData(item2, item2.AvarageCycle,count, ord,item2.Name,item2.Id));
                        ord++;
                    }
                    count++;
                }
            }
        }
        public BalansViewModel(ShellViewModel svm)
        {
            shellVM = svm;
        }
    }
}
