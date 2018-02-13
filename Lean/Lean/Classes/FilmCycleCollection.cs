using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Lean.Classes
{
    public class FilmCycleCollection:PropertyChangedBase
    {
        public BindableCollection<FilmOperationCollection> FOperationCollection { get; set; } = new BindableCollection<FilmOperationCollection>();
        public FilmCycleCollection()
        {

        }
        public FilmCycleCollection(int NoOfOperation)
        {
            for (int i = 0; i < NoOfOperation; i++)
            {
                FOperationCollection.Add(new FilmOperationCollection(i));
            }
        }
        public FilmCycleCollection(int NoOfOperation,List<string>names)
        {
            for (int i = 0; i < NoOfOperation; i++)
            {
                FOperationCollection.Add(new FilmOperationCollection(i,names[i]));
            }
        }
    }
}
