using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lean.Classes
{
    public class Test
    {
        public double MyProperty { get; set; }
        public Test()
        {
            Random rnd = new Random();
            int Ran = rnd.Next();
            MyProperty = Ran;
        }
    }
}
