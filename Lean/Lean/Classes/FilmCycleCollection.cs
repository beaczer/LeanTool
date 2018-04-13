using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Lean.Classes
{
    [Serializable]
    public class FilmCycleCollection
    {
        public int FCCId { get; set; }
        public BindableCollection<FilmOperationCollection> FOperationCollection { get; set; } = new BindableCollection<FilmOperationCollection>();
        public FilmCycleCollection()
        {

        }
        public FilmCycleCollection( int index)
        {
            FCCId = index;
        }
        public FilmCycleCollection(int NoOfOperation,int index)
        {
            FCCId = index;
            for (int i = 0; i < NoOfOperation; i++)
            {
                FOperationCollection.Add(new FilmOperationCollection(i));
            }
        }
        public FilmCycleCollection(int NoOfOperation,List<string>names,int index)
        {
            FCCId = index;
            for (int i = 0; i < NoOfOperation; i++)
            {
                FOperationCollection.Add(new FilmOperationCollection(i,names[i]));
            }
        }
    }
    
    }
