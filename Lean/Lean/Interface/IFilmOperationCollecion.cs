using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lean.Interface
{
    public interface IFilmOperationCollecion
    {
        int OperationId { get; set; }
        string OperationName { get; set; }
        bool On { get; set; }
        double StartTime{ get; set; }
        double StopTime { get; set; }
        double Time { get; set; }

    }
}

