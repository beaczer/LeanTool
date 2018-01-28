using Caliburn.Micro;
using Lean.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lean
{
    public class LineManagerViewModel:Screen
    {
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
                ListOfLine.Remove(ListOfLine.Where(x => x.LineName == (line as Line).LineName).First());
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
        }

    }
}
