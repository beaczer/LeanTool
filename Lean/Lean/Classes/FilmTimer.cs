using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lean.Classes
{
    public class FilmTimer
    {
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public double MiliSeconds { get; set; }

        public FilmTimer(int min, int sec, double milisec)
        {
            Minutes = min;
            Seconds = sec;
            MiliSeconds = milisec;
        }
        public void SetTime(int min, int sec, double milisec)
        {
            Minutes = min;
            Seconds = sec;
            MiliSeconds = milisec;
        }

        public FilmTimer SubstructTime(FilmTimer ft)
        {
            double CurrentTime = this.Minutes * 60 + this.Seconds + this.MiliSeconds / 1000;
            double SubstructTime = ft.Minutes * 60 + ft.Seconds + ft.MiliSeconds / 1000;
            double result = SubstructTime - CurrentTime;
            int minut = (int)result / 60;
            int sec = (int)result % 60;
            double ssec = (result - minut * 60 - sec) * 1000;
            ssec = Math.Round(ssec, 3);
            return new FilmTimer(minut, sec, ssec);
        }
        public override string ToString()
        {
            string a = this.Minutes + ":" + this.Seconds + ":" + this.MiliSeconds;
            return a;
        }
    }
}

