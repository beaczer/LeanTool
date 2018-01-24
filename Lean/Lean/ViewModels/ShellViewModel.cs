using Lean.Controls;
using System.Collections.Generic;

namespace Lean {
    public class ShellViewModel : Caliburn.Micro.PropertyChangedBase, IShell
    {
        public LineViewModel DataCalculetingVM { get; private set; } = new LineViewModel();

        private List<string> typeOfOperation = new List<string> { "Kontrola", "Przejœcie", "Czekanie", "Operacja" };

        public List<string> TypeOfOperation { get => typeOfOperation; set => typeOfOperation = value; }
        private List<AnalyseRow> ListOfRow = new List<AnalyseRow>();
        



    }
    
}