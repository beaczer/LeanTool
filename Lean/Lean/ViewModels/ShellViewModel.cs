using Caliburn.Micro;
using Lean.Controls;
using System.Collections.Generic;

namespace Lean {
    public class ShellViewModel : Caliburn.Micro.PropertyChangedBase, IShell
    {
        IWindowManager manager = new WindowManager();
        public LineViewModel DataCalculetingVM { get; private set; } = new LineViewModel();
        public LineManagerViewModel LineManagerVM { get; private set; } = new LineManagerViewModel();

        private List<string> typeOfOperation = new List<string> { "Kontrola", "Przejœcie", "Czekanie", "Operacja" };

        public List<string> TypeOfOperation { get => typeOfOperation; set => typeOfOperation = value; }
        private List<AnalyseRow> ListOfRow = new List<AnalyseRow>();
        
        public void ShowManager()
        {
            manager.ShowDialog(LineManagerVM, null, null);
        }


    }
    
}