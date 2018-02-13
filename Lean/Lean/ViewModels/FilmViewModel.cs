using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using System.Threading.Tasks;
using Lean.Classes;
using Lean.Interface;

namespace Lean.ViewModels
{
    public class FilmViewModel:Screen
    {
        private bool on;
        public bool On
        {
            get
            {
                return on;
            }
            set
            {
                on = value;
                NotifyOfPropertyChange(() => On);
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
        private int noColumns=0;
        public int NoColumns
        {
            get
            {
                return noColumns;
            }
            set
            {
                noColumns = value;
                NotifyOfPropertyChange(() => NoColumns);
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
        
        public BindableCollection<CycleAnalyse> CycleAnalyses { get; set; } = new BindableCollection<CycleAnalyse>();
        private List<string> TemporaryNames = new List<string>();
        int NoCycle = 0;
        int NoOperation = 0;
        public BindableCollection<FilmCycleCollection> FCycleCollection { get; set; } = new BindableCollection<FilmCycleCollection>();
       // public BindableCollection<FilmOperationCollection> FOperationCollection { get; set; } = new BindableCollection<FilmOperationCollection>();
       public FilmViewModel()
        {
            FCycleCollection.Add(new FilmCycleCollection());
            On = true;
        }
        public void AddData()
        {

            int index = FCycleCollection[NoCycle].FOperationCollection.Count();
            FCycleCollection[NoCycle].FOperationCollection.Add(new FilmOperationCollection(index));
            NoOperation = FCycleCollection[NoCycle].FOperationCollection.Count();
            if(NoCycle==0)CycleAnalyses.Add(new CycleAnalyse(index));
            
        }
        public void AddCycle()
        {
            On = false;
            GetTemporaryNames();
            FCycleCollection.Add(new FilmCycleCollection(NoOperation,TemporaryNames));
            
        }
        private void GetTemporaryNames()
        {
            foreach (var item in FCycleCollection[0].FOperationCollection)
            {
                TemporaryNames.Add(item.OperationName);
                
            }
        }

    }
}
