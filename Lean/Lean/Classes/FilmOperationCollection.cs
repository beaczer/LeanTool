using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Lean.Interface;

namespace Lean.Classes
{
    public class FilmOperationCollection:PropertyChangedBase, IFilmOperationCollecion
    {
       
        public int OperationId { get; set; }
        private string operationName;
        public string OperationName
        {
            get
            {
                return operationName;
            }
            set
            {
                operationName = value;
                NotifyOfPropertyChange(() => OperationName);
            }
        }
        private bool on;
        public bool On 
        {
            get
            { return on; }
            set
            {
                on = value;
                NotifyOfPropertyChange(() => On);
            }
        }
        private double startTime;
        public double StartTime
        {
            get
            {
                return startTime;
            }
            set
            {
                startTime = value;
                NotifyOfPropertyChange(() => StartTime);
            }
        }
        private double stopTime;
        public double StopTime
        {
            get
            {
                return stopTime;
            }
            set
            {
                stopTime = value;
                NotifyOfPropertyChange(() => StopTime);
                Time = CalculateTime(StartTime, StopTime);
            }
        }
        private double time;
        public double Time
        {
            get
            { return time; }
            set
            {
                time = value;
                NotifyOfPropertyChange(() => Time);
            }
        }

        public FilmOperationCollection()
        {

        }
        public FilmOperationCollection(int index)
        {
            OperationId = index;
            On = false;
        }
        public FilmOperationCollection(int index,string name)
        {
            OperationId = index;
            OperationName = name;
            On = false;
        }
        private double CalculateTime(double a, double b)
        {
            double result = b - a;
            return result;
        }
        
    }
}
