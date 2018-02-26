using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        

        
    }
    public partial class MainWindow : Window
    {

        public ObservableCollection<string> lista1;
        public ObservableCollection<User> lista;

        public MainWindow()
        {
            
            
            lista = new ObservableCollection<User>();

            User a1 = new User() { Id = 1 };
            User a2 = new User() { Id = 2 };
            lista.Add(a1);
            lista.Add(a2);

            InitializeComponent();
            this.dGrid.ItemsSource = lista;
            
        }
    }
}
