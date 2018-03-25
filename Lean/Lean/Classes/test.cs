using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lean.Classes
{
    public class Test
    {
        public BindableCollection<Test2> ListaIN { get; set; } = new BindableCollection<Test2>();
        public Test()
        {
            ListaIN.Add(new Test2());
            ListaIN.Add(new Test2());
            ListaIN.Add(new Test2());
        }
    }
    public class Test2:PropertyChangedBase
    {
        private double myProperty;
        public double MyProperty
        {
            get
            { return myProperty; }
            set
            {
                myProperty = value;
                NotifyOfPropertyChange(() => MyProperty);
            }
        }
        
        public Test2()
        {
            Random rnd = new Random();
            int Ran = rnd.Next();
            MyProperty = Ran;
        }
    }
}
