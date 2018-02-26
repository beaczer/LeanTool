using Caliburn.Micro;
using Lean.Classes;
using Lean.Controls;
using Lean.Interface;
using Lean.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Telerik.Windows.Controls;


namespace Lean {
    public class ShellViewModel : Caliburn.Micro.PropertyChangedBase, IShell,IObserwowany
    {
        List<IObserwator> ListOfObserwator = new List<IObserwator>();
        
        public LineViewModel DataCalculetingVM { get; private set; }
        public YamazumiViewModel YamazumiVM { get; set; }
        public LineManagerViewModel LineManagerVM { get; private set; } = new LineManagerViewModel();
        public BalansViewModel BalansVM { get; set; }
        public FilmViewModel FilmVM { get; set; } 

        private BindableCollection<string> typeOfOperation = new BindableCollection<string> { "Kontrola", "Przejœcie", "Czekanie", "Operacja" };
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
        public bool ifStart=false;
        private double videoTime;
        public double VideoTime
        {
            get { return videoTime; }
            set { videoTime = value;
                NotifyOfPropertyChange(() => VideoTime);
            }
        }
        Timer tim=new Timer(showTime);
       
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
            timer.Tick += new System.EventHandler(timer_Tick);
            YamazumiVM = new YamazumiViewModel(this);
            FilmVM = new FilmViewModel(this);
            DataCalculetingVM = new LineViewModel(this);
            BalansVM = new BalansViewModel(this);

            AddObserwatora(DataCalculetingVM);
            AddObserwatora(YamazumiVM);
            AddObserwatora(BalansVM);
            AddObserwatora(FilmVM);
            

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
            if (me!=null)
            {
                me.Play();
                timer.Start();
                StartFT.SetTime(stopWatch.Elapsed.Minutes, stopWatch.Elapsed.Seconds, stopWatch.Elapsed.Milliseconds);
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
            if (result == true && me is MediaElement&& btnPlay is Button)
            {
                // Open document  
                (me as MediaElement).Source = new Uri(dialog.FileName);
                (btnPlay as Button).IsEnabled = true;
                (me as MediaElement).Play();
                (me as MediaElement).Stop();
                if((me as MediaElement).NaturalDuration.HasTimeSpan)
                TotalSecFilm = (me as MediaElement).NaturalDuration.TimeSpan.TotalSeconds;
                
            }
            stopWatch.Reset() ;
            
        }
        public void SetFilmTime(MediaElement me,RadSlider rs)
        {
            me.Position =TimeSpan.FromSeconds( rs.Value);
        }
        public void PlayVideo(MediaElement me)
        {
            if (me !=null)
            {
                me.Play();
                stopWatch.Start();
            }
        }
        public void StopVideo(MediaElement me)
        {
            if (me !=null)
            {
                me.Stop();
                stopWatch.Start();
            }
        }
        public void StopAnalyse(MediaElement me)
        {
            if (me != null)
            {
                timer.Stop();
                me.Pause();
                stopWatch.Stop();
                StopFT.SetTime(stopWatch.Elapsed.Minutes, stopWatch.Elapsed.Seconds, stopWatch.Elapsed.Milliseconds);
                NotifyOfPropertyChange(() => StopFT);
                DiffFT = StartFT.SubstructTime(StopFT);
                ifStart = false;
                this.InformObserwator();
            }
        }
        public void PauseVideo(MediaElement me)
        {
            if (me!=null)
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

        
    }

}