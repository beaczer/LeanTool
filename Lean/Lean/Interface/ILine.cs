using Caliburn.Micro;
using Lean.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lean.Interface
{
     public interface ILine
    {
         BindableCollection<IOperation> ListOfOperation { get; set; }
    }
}
