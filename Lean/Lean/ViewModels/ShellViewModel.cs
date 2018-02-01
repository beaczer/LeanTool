using Caliburn.Micro;
using Lean.Classes;
using Lean.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Lean {
    public class ShellViewModel : Caliburn.Micro.PropertyChangedBase, IShell
    {
        IWindowManager manager = new WindowManager();
        public LineViewModel DataCalculetingVM { get; private set; } = new LineViewModel();
        public LineManagerViewModel LineManagerVM { get; private set; } = new LineManagerViewModel();

        private BindableCollection<string> typeOfOperation = new BindableCollection<string> { "Kontrola", "Przejœcie", "Czekanie", "Operacja" };

        public BindableCollection<string> TypeOfOperation { get => typeOfOperation; set => typeOfOperation = value; }
        private List<AnalyseRow> ListOfRow = new List<AnalyseRow>();
        
        //public void ShowManager()
        //{
        //    manager.ShowDialog(LineManagerVM, null, null);
        //}
        public BindableCollection<Line> ListOfLine { get; set; } = new BindableCollection<Line>();
        private Operation currentOperation;
        public Operation CurrentOperation
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
            }


        }
        public void TellCurrentOperation(object obj)
        {
            if (obj is Operation)
            {
                CurrentOperation = (obj as Operation);
            }

        }
        public void AddOperation(string name)
        {
            CurrentLine.ListOfOperation.Add(new Operation(name));
        }
        public void RemoveOperation(int name)
        {
            CurrentLine.ListOfOperation.RemoveAt(name);
            CurrentOperation = null;
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
            }
        }
        public void PlayVideo(MediaElement me)
        {
            if (me !=null)
            {
                me.Play();
            }
        }
        public void StopVideo(MediaElement me)
        {
            if (me !=null)
            {
                me.Stop();
            }
        }
        public void PauseVideo(MediaElement me)
        {
            if (me!=null)
            {
                me.Pause();
            }
        }


    }

}