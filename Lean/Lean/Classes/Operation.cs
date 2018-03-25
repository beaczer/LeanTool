using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Lean.Classes
{
    public class Operation : PropertyChangedBase,IOperation
    {
        public int OperationId { get; private set; }
        public string OperationName { get; private set; }
        public BindableCollection<CycleAnalyse> CycleAnalyses { get; set; } = new BindableCollection<CycleAnalyse>();
        public BindableCollection<FilmCycleCollection> FCycleCollection { get; set; } = new BindableCollection<FilmCycleCollection>();
        private double waitingTime;
        public double WaitingTime
        {
            get
            { return waitingTime; }
            set
            {
                waitingTime = value;
                NotifyOfPropertyChange(() => WaitingTime);
            }
        }
        private double aVTime;
        public double AVTime
        {
            get
            { return aVTime; }
            set
            {
                aVTime = value;
                NotifyOfPropertyChange(() => AVTime);
            }
        }
        private double controlTime;
        public double ControlTime
        {
            get
            { return controlTime; }
            set
            {
                controlTime = value;
                NotifyOfPropertyChange(() => ControlTime);
            }
        }
        private double transportTime;
        public double TransportTime { get
            { return transportTime; }
            set { transportTime = value;
                NotifyOfPropertyChange(() => TransportTime);
                    } }
       
        
        private double sum;
        public double Sum
        {
            get
            {
                return sum;
            }
            set
            {
                sum = value;
                NotifyOfPropertyChange(() => Sum);
            }
        }
        private BindableCollection<ElementaryOperation> listOfOperation;
        public BindableCollection<ElementaryOperation> ListOfOperation
        {
            get

            {
                return listOfOperation;
            }
            set
            {
                listOfOperation = value;
                NotifyOfPropertyChange(() => ListOfOperation);
                sum = sumAll();
            }
        } 
        private double sumAll()
        {
            double temp = 0;
            foreach (var item in ListOfOperation)
            {
                temp += item.AvgTime;
            }
            return temp;
        }
        public Operation(string name)
        {
            OperationName = name;
            ListOfOperation = new BindableCollection<ElementaryOperation>();
            FCycleCollection.Add(new FilmCycleCollection(0));
            CycleAnalyses.CollectionChanged += Calculate;
            
        }

        private void Calculate(object sender, NotifyCollectionChangedEventArgs e)
        {
           
                WaitingTime = CycleAnalyses.Where(x => x.OperationType == TypeOfOperation.Czekanie).Sum(z => z.AvarageCycle);
                AVTime = CycleAnalyses.Where(x => x.OperationType == TypeOfOperation.Kontrola).Sum(z => z.AvarageCycle);
                ControlTime = CycleAnalyses.Where(x => x.OperationType == TypeOfOperation.Kontrola).Sum(z => z.AvarageCycle);
                TransportTime = CycleAnalyses.Where(x => x.OperationType == TypeOfOperation.Kontrola).Sum(z => z.AvarageCycle);
          
        }

        public Operation()
        {
            ListOfOperation = new BindableCollection<ElementaryOperation>();
            FCycleCollection.Add(new FilmCycleCollection(0));
            CycleAnalyses.CollectionChanged += Calculate;
        }
    }
}
