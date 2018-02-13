using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Lean.Classes
{
    public class FilmOperationCollection: PropertyChangedBase
    {
       
        public int OperationId { get; set; }
        private string operationName;
        public string OperationName
        {
            get
            {
                return operationName;
            }
            set
            {
                operationName = value;
                NotifyOfPropertyChange(() => OperationName);
            }
        }
        public FilmOperationCollection(int index)
        {
            OperationId = index;
        }
        public FilmOperationCollection(int index,string name)
        {
            OperationId = index;
            OperationName = name;
        }
        public BindableCollection<FilmData> FilmDataCollection { get; set; } = new BindableCollection<FilmData>();
        public void AddOperation()
        {
            FilmDataCollection.Add(new FilmData());
        }
    }
}
