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
    public class FilmViewModel:Screen,IObserwator
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
        private FilmTimer startFT = new FilmTimer(0, 0, 0);
        public FilmTimer StartFT
        {
            get
            {
                return startFT;
            }
            set
            {
                startFT = value;
                NotifyOfPropertyChange(() => StartFT);
            }
        }
        private FilmTimer stopFT = new FilmTimer(0, 0, 0);
        public FilmTimer StopFT
        {
            get
            {
                return stopFT;
            }
            set
            {
                stopFT = value;
                NotifyOfPropertyChange(() => StopFT);
            }
        }
        private ShellViewModel ShellVM { get; set; }
        //public BindableCollection<CycleAnalyse> CycleAnalyses { get; set; } = new BindableCollection<CycleAnalyse>();
        private List<string> TemporaryNames = new List<string>();
        int NoCycle = 0;
        int NoOperation = 0;
        public BindableCollection<FilmCycleCollection> FCycleCollection { get; set; } = new BindableCollection<FilmCycleCollection>();

        private IFilmOperationCollecion currentOperationCollection;
        public IFilmOperationCollecion CurrentOperationCollection
        {
            get
            {
                return currentOperationCollection;
            }
            set
            {
                currentOperationCollection = value;
                NotifyOfPropertyChange(() => CurrentOperationCollection);
            }
        }
        private void CompleteStartTime(int[]tab)
        {
            CurrentOperation.FCycleCollection[tab[0]].FOperationCollection[tab[1]].StartTime = StartFT.Seconds+StartFT.Minutes*60+StartFT.MiliSeconds/1000;
        }
        private void CompleteStopTime(int[] tab)
        {
            CurrentOperation.FCycleCollection[tab[0]].FOperationCollection[tab[1]].StopTime = StopFT.Seconds+StopFT.Minutes*60+StopFT.MiliSeconds/1000;
        }
        public FilmViewModel(ShellViewModel svm)
        {
            ShellVM = svm;
            CurrentOperation = new Operation();
            CurrentOperation.FCycleCollection = svm.CurrentOperation.FCycleCollection;
                //FCycleCollection.Add(new FilmCycleCollection(NoCycle));
            On = true;
            CurrentOperationCollection = new FilmOperationCollection();
        }
        public void AddData()
        { 
            int index = CurrentOperation.FCycleCollection[NoCycle].FOperationCollection.Count();
            CurrentOperation.FCycleCollection[NoCycle].FOperationCollection.Add(new FilmOperationCollection(index));
            NoOperation = CurrentOperation.FCycleCollection[NoCycle].FOperationCollection.Count();
            if (NoCycle == 0)
            {
                CurrentOperation.CycleAnalyses.Add(new CycleAnalyse(index));
            }
        }
        public void AddCycle()
        {
            On = false;
            GetTemporaryNames();
            if (CurrentOperation.FCycleCollection.Count == 1)
            {
                foreach (var item in CurrentOperation.CycleAnalyses)
                {
                    item.list.Add(0);
                }
            }
            NoCycle++;
            CurrentOperation.FCycleCollection.Add(new FilmCycleCollection(NoOperation,TemporaryNames,NoCycle));
            
            GetNamesForCycleAnalyse();
            foreach (var item in CurrentOperation.CycleAnalyses)
            {
                    item.list.Add(0);
            }
            
            
         }
        public void MakeActive(object dc,int dc1)
        {
            int index = (dc as FilmOperationCollection).OperationId;
            foreach (var item in CurrentOperation.FCycleCollection)
            {
                foreach (var i in item.FOperationCollection)
                {
                    i.On = false;
                }
            }
            CurrentOperation.FCycleCollection[dc1].FOperationCollection[index].On = true;
            CurrentOperationCollection = CurrentOperation.FCycleCollection[dc1].FOperationCollection[index];
        }
        private int[] FindActiceFCycleCollection()
        {
            int[] tab = new int[2];
            if (CurrentOperation.FCycleCollection.Count>0)
            {
                foreach (var item in CurrentOperation.FCycleCollection)
                {
                    foreach (var i in item.FOperationCollection)
                    {
                        if (i.On == true)
                        {
                            tab[0] = item.FCCId;
                            tab[1] = i.OperationId;
                        }
                    }
                }
            }
            return tab;
        }
        
        private void GetTemporaryNames()
        {
            TemporaryNames=new List<string>();
            foreach (var item in CurrentOperation.FCycleCollection[0].FOperationCollection)
            {
                TemporaryNames.Add(item.OperationName);
            }
        }
        private void GetNamesForCycleAnalyse()
        {
            for (int i = 0; i < TemporaryNames.Count; i++)
            {
                CurrentOperation.CycleAnalyses[i].Name = TemporaryNames[i];
            }
        }
        public void DeleteLastOp()
        {
            CurrentOperation.FCycleCollection[0].FOperationCollection.RemoveAt(FCycleCollection[0].FOperationCollection.Count - 1);

        }
        public void DeleteCycle()
        {
            CurrentOperation.FCycleCollection.RemoveAt(FCycleCollection.Count-1);
            CurrentOperation.CycleAnalyses.RemoveAt(CurrentOperation.CycleAnalyses.Count - 1);
        }
        private void CompleteCycleAnalyse()
        {
            int[] tab = FindActiceFCycleCollection();
            CurrentOperation.CycleAnalyses[tab[1]].list[tab[0]] = CurrentOperation.FCycleCollection[tab[0]].FOperationCollection[tab[1]].Time;
        }
        public void Aktualizuj()
        {

            CurrentOperation= ShellVM.CurrentOperation;
            if (CurrentOperation.FCycleCollection.Count > 1) { 
            if (ShellVM.ifStart)
            {
            
                StartFT = ShellVM.StartFT;
                CompleteStartTime(FindActiceFCycleCollection());
            }
            else
            {
                    StopFT = ShellVM.StopFT;
                CompleteStopTime(FindActiceFCycleCollection());
                CompleteCycleAnalyse();
            }
            }
        }
    }
}
