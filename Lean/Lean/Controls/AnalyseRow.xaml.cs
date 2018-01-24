using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lean.Controls
{
    /// <summary>
    /// Interaction logic for AnalyseRow.xaml
    /// </summary>
    public partial class AnalyseRow : UserControl
    {
        private List<string> typeOfOperation = new List<string> { "Kontrola", "Przejście", "Czekanie", "Operacja" };

        public List<string> TypeOfOperation { get => typeOfOperation;}
        public string OperationDescription { get; set; }
        public double T1 { get; set; }
        public double T2 { get; set; }
        public double T3 { get; set; }
        public double T4 { get; set; }
        public double T5 { get; set; }
        public double T6 { get; set; }
        public double T7 { get; set; }
        public double T8 { get; set; }
        public double T9 { get; set; }
        public double T10 { get; set; }
        public double TMin { get; set; }
        public double TMax { get; set; }
        public double TAvr { get; set; }
        public double TMod { get; set; }
        public double TFluk { get; set; }

        public AnalyseRow()
        {
            InitializeComponent();
        }



        

    }
}
