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
    
    public class YamazumiViewModel : Screen, IObserwator
    {
        private ShellViewModel shellVM;
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
        public YamazumiViewModel(ShellViewModel svm)
        {
            shellVM = svm;
            
        }
        
        public void PrepareDate()
        {
            foreach (var item in CurrentLine.ListOfOperation)
            {
                item.TransportTime =   item.CycleAnalyses.Where(x => x.OperationType == TypeOfOperation.Transport).Select(x=>x.AvarageCycle).Sum();
                item.WaitingTime   =   item.CycleAnalyses.Where(x => x.OperationType == TypeOfOperation.Czekanie).Select(x => x.AvarageCycle).Sum();
                item.ControlTime   =   item.CycleAnalyses.Where(x => x.OperationType == TypeOfOperation.Kontrola).Select(x => x.AvarageCycle).Sum();
                item.AVTime        =   item.CycleAnalyses.Where(x => x.OperationType == TypeOfOperation.ValueAdded).Select(x => x.AvarageCycle).Sum();
                
            }
            NotifyOfPropertyChange(() => CurrentLine.ListOfOperation);
            
        }
        public void Aktualizuj()
        {
            if (shellVM.CurrentLine != null)
            {
                CurrentLine = shellVM.CurrentLine;
                PrepareDate();       
            }
            
        }
    }
}
