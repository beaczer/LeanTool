using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lean.Interface
{
    public interface IVideoObservation
    {
        int Time { get; set; }
        void AddObserwatora(IVideoObserver o);
        void RemoveObserwator(IVideoObserver o);
        void InformVideoObserwator();
    }
}
