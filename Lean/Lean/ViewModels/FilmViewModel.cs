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
        public BindableCollection<CycleAnalyse> CycleAnalyses { get; set; } = new BindableCollection<CycleAnalyse>();
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
            FCycleCollection[tab[0]].FOperationCollection[tab[1]].StartTime = StartFT.Seconds;
        }
        private void CompleteStopTime(int[] tab)
        {
            FCycleCollection[tab[0]].FOperationCollection[tab[1]].StopTime = StopFT.Seconds;
        }
        public FilmViewModel(ShellViewModel svm)
        {
            ShellVM = svm;
            FCycleCollection.Add(new FilmCycleCollection(NoCycle));
            On = true;
            CurrentOperationCollection = new FilmOperationCollection();
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
            NoCycle++;
            FCycleCollection.Add(new FilmCycleCollection(NoOperation,TemporaryNames,NoCycle));
            if(NoCycle==1)GetNamesForCycleAnalyse();
            
         }
        public void MakeActive(object dc,int dc1)
        {
            int index = (dc as FilmOperationCollection).OperationId;
            foreach (var item in FCycleCollection)
            {
                foreach (var i in item.FOperationCollection)
                {
                    i.On = false;
                }
            }
            FCycleCollection[dc1].FOperationCollection[index].On = true;
            CurrentOperationCollection = FCycleCollection[dc1].FOperationCollection[index];
        }
        private int[] FindActiceFCycleCollection()
        {
            int[] tab = new int[2];
            if (FCycleCollection.Count>0)
            {
                foreach (var item in FCycleCollection)
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
            foreach (var item in FCycleCollection[0].FOperationCollection)
            {
                TemporaryNames.Add(item.OperationName);
            }
        }
        private void GetNamesForCycleAnalyse()
        {
            for (int i = 0; i < TemporaryNames.Count; i++)
            {
                CycleAnalyses[i].Name = TemporaryNames[i];
            }
        }

        public void Aktualizuj()
        {
            if (FCycleCollection.Count > 1) { 
            if (ShellVM.ifStart)
            {
                StartFT = ShellVM.StartFT;
                CompleteStartTime(FindActiceFCycleCollection());
            }
            else
            {
                StopFT = ShellVM.StopFT;
                CompleteStopTime(FindActiceFCycleCollection());
            }
            }
        }
    }
}
