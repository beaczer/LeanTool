using Caliburn.Micro;
using Lean.Classes;
using Lean.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lean
{
    public class LineViewModel:Screen, IObserwator
    {
        private ShellViewModel ShellVM { get; set; }
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
        private IOperation currentOperation;
        public IOperation CurrentOperation
        {
            get
            {
                return currentOperation;
            }
            set
            {
                currentOperation = value;
                NotifyOfPropertyChange(() => CurrentOperation);
            }
        }
        public LineViewModel(ShellViewModel svm)
        {
            ShellVM = svm;
        }
        public void AddData()
        {
            if(CurrentOperation!=null)
            { 
            CurrentOperation.ListOfOperation.Add(new ElementaryOperation()
            {
                OperationId = CurrentOperation.ListOfOperation.Count,
                OperationName = "Opis operacji",
                ElementaryOperationType = TypeOfOperation.Niezdefiniowane,
            });
            }
        }
        public void CalculateTime(ElementaryOperation oper, string time7)
        {
            if (oper is ElementaryOperation)
            {
                int index = oper.OperationId;
                //oper.ElementaryOperationTimes[index].Time = double.Parse(time7);
                oper.MaxTime = oper.ElementaryOperationTimes.Max(x => x.Time);
                oper.MinTime = oper.ElementaryOperationTimes.Min(x => x.Time);
                oper.AvgTime = oper.ElementaryOperationTimes.Average(x => x.Time);
            }
        }
        
        public void Aktualizuj()
        {
            CurrentOperation=ShellVM.CurrentOperation;
        }
    }
}
