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
        private ShellViewModel shellVM { get; set; }
        public BindableCollection<ChartElement> Czekanie { get; set; } = new BindableCollection<ChartElement>();
        public BindableCollection<ChartElement> Kontrola { get; set; } = new BindableCollection<ChartElement>();

        //private void GetData()
        //{
        //    Data1 = new BindableCollection<ChartElement>() {
        //     new ChartElement() { Category="KIT" , Count=1},
        //     new ChartElement() { Category="SLEEPER SUIT" , Count=8},
        //     new ChartElement() { Category="KIT 2" , Count=6},
        //    };

        //    Data2 = new BindableCollection<ChartElement>() {
        //     new ChartElement() { Category="KIT" , Count=4},
        //     new ChartElement() { Category="SLEEPER SUIT" , Count=9},
        //     new ChartElement() { Category="KIT 2" , Count=3},
        //    };
        //}


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

        }
        public BalansViewModel(ShellViewModel svm)
        {
            shellVM = svm;
        }
    }
}
