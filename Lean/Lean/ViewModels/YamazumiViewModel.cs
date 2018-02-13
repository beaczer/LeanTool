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
    public class Man:PropertyChangedBase
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
        public double czekanie;
        public double Czekanie
        {
            get
            {
                return czekanie;
            }
            set
            {
                czekanie = value;
                NotifyOfPropertyChange(() => Czekanie);

            }
        }
        private double kontrola;
        public double Kontrola
        {
            get { return kontrola; }
            set
            {
                kontrola = value;
                NotifyOfPropertyChange(() => Kontrola);
            }
        }
        
        private double niezdefiniowane;
        public double Niezdefiniowane
        {
            get { return niezdefiniowane; }
            set
            {
                niezdefiniowane = value;
                NotifyOfPropertyChange(() => Niezdefiniowane);
            }
        }
        private double trasport;
        public double Trasport
        {
            get { return trasport; }
            set
            {
                trasport = value;
                NotifyOfPropertyChange(() => Trasport);
            }
        }
        private double valueAdded;
        public double ValueAdded
        {
            get { return valueAdded; }
            set
            {
                valueAdded = value;
                NotifyOfPropertyChange(() => ValueAdded);
            }
        }
        private double sum;
        public double Sum
        {
            get { return sum; }
            set
            {
                sum = value;
                NotifyOfPropertyChange(() => Sum);
            }
        }
        
        public Man(int no)
        {
            id = no;
        }
    }
    public class YamazumiViewModel : Screen, IObserwator
    {
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
        
        public void Aktualizuj(IOperation op, ILine line)
        {
            CurrentLine = line;
            PrepareDate();
        }
        
        public void PrepareDate()
        {
            if(CurrentLine!=null)
            { 
            int noPeople=0;
                ManSet = new BindableCollection<Man>();
            foreach (var item in CurrentLine.ListOfOperation)
            {
                foreach (var item1 in item.ListOfOperation)
                {
                    noPeople = item1.Human;     
                }
            }
            for (int i = 1; i < (noPeople+1); i++)
            {
                ManSet.Add(new Man(i));
            }
            foreach (var item in CurrentLine.ListOfOperation)
            {
                foreach (var item1 in item.ListOfOperation)
                {
                    foreach (var man in ManSet)
                    {
                        man.Czekanie=item.ListOfOperation.Where(x => x.Human == man.Id && x.ElementaryOperationType ==
                        TypeOfOperation.Czekanie).Sum(x=>x.AvgTime);
                        man.Kontrola= item.ListOfOperation.Where(x => x.Human == man.Id && x.ElementaryOperationType == 
                        TypeOfOperation.Kontrola).Sum(z => z.AvgTime);
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
