using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lean.Classes
{
    public class LineToSave
    {
        public string Name;
        public List<IOperation> ListOfOperation { get; set; } = new List<IOperation>();

        public LineToSave(string n, BindableCollection<IOperation> list)
        {
            foreach (var item in list)
            {
                ListOfOperation.Add(item);
            }
        }
    }
}
