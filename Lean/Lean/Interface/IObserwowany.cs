using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lean.Interface
{
    public interface IObserwowany
    {
        void AddObserwatora(IObserwator o);
        void RemoveObserwator(IObserwator o);
        void InformObserwator();
    }
}
