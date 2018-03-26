using Caliburn.Micro;
using Lean.Classes;
using Lean.Controls;
using Lean.Interface;
using Lean.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Telerik.Windows.Controls;

namespace Lean {
    public class ShellViewModel : Caliburn.Micro.PropertyChangedBase, IShell, IObserwowany
    {
        List<IObserwator> ListOfObserwator = new List<IObserwator>();

        public LineViewModel DataCalculetingVM { get; private set; }
        public YamazumiViewModel YamazumiVM { get; set; }
        public LineManagerViewModel LineManagerVM { get; private set; } = new LineManagerViewModel();
        public BalansViewModel BalansVM { get; set; }
        public FilmViewModel FilmVM { get; set; }
        public SummaryViewModel SummaryVM { get; set; }
        private BindableCollection<string> typeOfOperation = new BindableCollection<string> { "Kontrola", "Przej�cie", "Czekanie", "Operacja" };
        public BindableCollection<string> TypeOfOperation { get => typeOfOperation; set => typeOfOperation = value; }
        private double totalSecFilm;
        public double TotalSecFilm
        {
            get
            {
                return totalSecFilm;
            }
            set
            {
                totalSecFilm = value;
                NotifyOfPropertyChange(() => TotalSecFilm);
            }
        }
        private Stopwatch stopWatch = new Stopwatch();
        private List<AnalyseRow> ListOfRow = new List<AnalyseRow>();
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
        public bool ifStart = false;
        private double videoTime;
        public double VideoTime
        {
            get { return videoTime; }
            set { videoTime = value;
                NotifyOfPropertyChange(() => VideoTime);
            }
        }
        Timer tim = new Timer(showTime);

        private static void showTime(object state)
        {
            throw new NotImplementedException();
        }

        private FilmTimer diffFT;
        public FilmTimer DiffFT
        {
            get
            {
                return diffFT;
            }
            set
            {
                diffFT = value;
                NotifyOfPropertyChange(() => DiffFT);
            }
        }
        DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(0.5) };
        public ShellViewModel()
        {
            CurrentOperation = new Operation();

            timer.Tick += new System.EventHandler(timer_Tick);
            YamazumiVM = new YamazumiViewModel(this);
            FilmVM = new FilmViewModel(this);
            DataCalculetingVM = new LineViewModel(this);
            BalansVM = new BalansViewModel(this);
            SummaryVM = new SummaryViewModel(this);
            AddObserwatora(DataCalculetingVM);
            AddObserwatora(YamazumiVM);
            AddObserwatora(BalansVM);
            AddObserwatora(FilmVM);
            AddObserwatora(SummaryVM);
        }

        private void timer_Tick(object sender, EventArgs e)
        {

            VideoTime = stopWatch.Elapsed.Seconds;

        }

        public BindableCollection<Line> ListOfLine { get; set; } = new BindableCollection<Line>();
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
        private Line currentLine;
        public Line CurrentLine
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
        public void AddLine(string Text)
        {
            Line line = new Line(Text);
            ListOfLine.Add(line);
        }
        public void RemoveLine(object line)
        {
            if (line is Line)
            {
                Line l = line as Line;
                ListOfLine.Remove(l);
                CurrentLine = null;
            }
        }
        public void TellCurrentLine(object obj)
        {
            if (obj is Line)
            {
                CurrentLine = (obj as Line);
                InformObserwator();
            }
        }
        public void TellCurrentOperation(object obj)
        {
            if (obj is Operation)
            {
                CurrentOperation = (obj as Operation);
                InformObserwator();
            }
        }
        public void AddOperation(string name)
        {
            CurrentOperation = new Operation(name);
            CurrentLine.ListOfOperation.Add(CurrentOperation);
        }
        public void RemoveOperation(int name)
        {
            CurrentLine.ListOfOperation.RemoveAt(name);
            CurrentOperation = null;

        }
        public void StartAnalyse(MediaElement me)
        {
            if (me != null)
            {
                StartFT.SetTime(me.Position.Minutes, me.Position.Seconds, me.Position.Milliseconds);
                me.Play();
                //double ts = double.Parse(me.Position.Seconds.ToString()) + double.Parse((me.Position.Milliseconds / 1000).ToString());

                timer.Start();

                //StartFT.SetTime(stopWatch.Elapsed.Minutes, stopWatch.Elapsed.Seconds, stopWatch.Elapsed.Milliseconds);
                NotifyOfPropertyChange(() => StartFT);
                stopWatch.Start();
                ifStart = true;
                this.InformObserwator();
            }
        }
        public void SetTime(int m, int s, int ss, MediaElement me)
        {
            double seconds = (m * 60) + s + (ss / 1000);
            me.Position = TimeSpan.FromSeconds(seconds);
            stopWatch.Reset();
            VideoTime = seconds;

            // var x = me.NaturalDuration.TimeSpan.TotalSeconds;
        }


        public void PauseAnalyse(MediaElement me)
        {
            if (me != null)
            {
                me.Pause();
                stopWatch.Stop();
            }
        }
        public void LoadVideo(object me, object btnPlay)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.FileName = "Videos";
            dialog.DefaultExt = ".WMV"; // Default file extension 
            dialog.Filter = "WMV file (.wm)|*.wmv"; // Filter files by extension 
            Nullable<bool> result = dialog.ShowDialog();
            if (result == true && me is MediaElement && btnPlay is Button)
            {
                // Open document  
                (me as MediaElement).Source = new Uri(dialog.FileName);
                (btnPlay as Button).IsEnabled = true;
                (me as MediaElement).Play();
                (me as MediaElement).Stop();
                if ((me as MediaElement).NaturalDuration.HasTimeSpan)
                    TotalSecFilm = (me as MediaElement).NaturalDuration.TimeSpan.TotalSeconds;

            }
            stopWatch.Reset();

        }
        public void SetFilmTime(MediaElement me, RadSlider rs)
        {
            me.Position = TimeSpan.FromSeconds(rs.Value);
        }
        public void PlayVideo(MediaElement me)
        {
            if (me != null)
            {
                me.Play();
                stopWatch.Start();
            }
        }
        public void StopVideo(MediaElement me)
        {
            if (me != null)
            {
                me.Stop();
                stopWatch.Start();
            }
        }
        public void StopAnalyse(MediaElement me)
        {
            if (me != null)
            {


                //StopFT.SetTime(me.Position.Minutes, me.Position.Seconds, Math.Round((double.Parse(me.Position.Milliseconds.ToString())), 1));
                me.Pause();

                StopFT.SetTime(me.Position.Minutes, me.Position.Seconds, me.Position.Milliseconds);
                timer.Stop();

                stopWatch.Stop();
                //  StopFT.SetTime(stopWatch.Elapsed.Minutes, stopWatch.Elapsed.Seconds, stopWatch.Elapsed.Milliseconds);
                NotifyOfPropertyChange(() => StopFT);
                DiffFT = StartFT.SubstructTime(StopFT);

                ifStart = false;
                this.InformObserwator();
            }
        }
        public void PauseVideo(MediaElement me)
        {
            if (me != null)
            {
                me.Pause();
                stopWatch.Stop();

            }
        }
        public void AddObserwatora(IObserwator o)
        {
            ListOfObserwator.Add(o);
        }
        public void RemoveObserwator(IObserwator o)
        {
            throw new NotImplementedException();
        }
        public void InformObserwator()
        {
            foreach (var item in ListOfObserwator)
            {
                item.Aktualizuj();
            }
        }
        public void SaveData()
        {
            BinaryFormatter bf = new BinaryFormatter();
            //DataToSave dt = new DataToSave(currentLine.LineName);
            
            //using (Stream fStream = new FileStream("lineInfo.txt", FileMode.Create, FileAccess.Write, FileShare.None))
            //{
            //    bf.Serialize(fStream, dt);
            //}
        }
    }
    [Serializable]
    public class DataToSave
    {
        string LineName;
        BindableCollection<ElementaryOperationToSave> ListOfOperation = new BindableCollection<ElementaryOperationToSave>();
        public BindableCollection<CycleAnalyseToSave> CycleAnalyses { get; set; } = new BindableCollection<CycleAnalyseToSave>();
        public BindableCollection<FilmCycleCollectionToSave> FCycleCollection { get; set; } = new BindableCollection<FilmCycleCollectionToSave>();

        public DataToSave(string name,BindableCollection<ElementaryOperation> list, BindableCollection<CycleAnalyse> CycleAnalyses,
                         BindableCollection<FilmCycleCollection> FCycleCollection)
        {
            LineName = name;
            foreach (var item in CycleAnalyses)
            {
                this.CycleAnalyses.Add(new CycleAnalyseToSave(item.Id, item.OperationType, item.Name, item.list, item.AvarageCycle, item.MinCycle, item.MaxCycle));
            }
            foreach (var item in FCycleCollection)
            {
                this.FCycleCollection.Add(new FilmCycleCollectionToSave(item.FCCId, item.FOperationCollection));
            }
            foreach (var item in list)
            {
                ListOfOperation.Add(new ElementaryOperationToSave(item.OperationId, item.OperationName, item.ElementaryOperationTimes, item.ElementaryOperationType,
                    item.AvgTime, item.MinTime, item.MaxTime, item.Freq, item.Stability));
            }
        }
    }
    class OperationToSave
    {
        public BindableCollection<ElementaryOperationToSave> ListOfOperation { get; set; } = new BindableCollection<ElementaryOperationToSave>();
        public BindableCollection<CycleAnalyse> CycleAnalyses { get; set; } = new BindableCollection<CycleAnalyse>();
        public BindableCollection<FilmCycleCollection> FCycleCollection { get; set; } = new BindableCollection<FilmCycleCollection>();
        public double WaitingTime { get; set; }
        public double AVTime { get; set; }
        public double ControlTime { get; set; }
        public double TransportTime { get; set; }
        public string OperationName { get; set; }
    }
}


