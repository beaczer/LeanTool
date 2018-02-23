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

        private BindableCollection<Man> manSet = new BindableCollection<Man>();
        public BindableCollection<Man> ManSet
        {
            get
            {
                return manSet;
            }
            set
            {
                manSet = value;
                NotifyOfPropertyChange(() => ManSet);
            }
        }
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
            PrepareDate();
        }
        public BalansViewModel(ShellViewModel svm)
        {
            shellVM = svm;
        }
        public void PrepareDate()
        {
            if (CurrentLine != null)
            {
                int noPeople = 0;
                ManSet = new BindableCollection<Man>();
                foreach (var item in CurrentLine.ListOfOperation)
                {
                    foreach (var item1 in item.ListOfOperation)
                    {
                        noPeople = item1.Human;
                    }
                }
                for (int i = 1; i < (noPeople + 1); i++)
                {
                    ManSet.Add(new Man(i));
                }
                foreach (var item in CurrentLine.ListOfOperation)
                {
                    foreach (var item1 in item.ListOfOperation)
                    {
                        foreach (var man in ManSet)
                        {
                            man.Czekanie = item.ListOfOperation.Where(x => x.Human == man.Id && x.ElementaryOperationType ==
                              TypeOfOperation.Czekanie).Sum(x => x.AvgTime);
                            Czekanie.Add(new ChartElement("Czekanie", man.Czekanie));
                            man.Kontrola = item.ListOfOperation.Where(x => x.Human == man.Id && x.ElementaryOperationType ==
                             TypeOfOperation.Kontrola).Sum(z => z.AvgTime);
                            Czekanie.Add(new ChartElement("Kontrola", man.Kontrola));
                            man.Niezdefiniowane = item.ListOfOperation.Where(x => x.Human == man.Id && x.ElementaryOperationType ==
                            TypeOfOperation.Niezdefiniowane).Sum(z => z.AvgTime);
                            man.ValueAdded = item.ListOfOperation.Where(x => x.Human == man.Id && x.ElementaryOperationType ==
                            TypeOfOperation.ValueAdded).Sum(z => z.AvgTime);
                            man.Trasport = item.ListOfOperation.Where(x => x.Human == man.Id && x.ElementaryOperationType ==
                            TypeOfOperation.Transport).Sum(z => z.AvgTime);
                        }
                    }
                }
            }
        }
    }
}
