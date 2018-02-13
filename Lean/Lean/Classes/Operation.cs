using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Lean.Classes
{
    public class Operation : PropertyChangedBase, IOperation
    {
        public int OperationId { get; private set; }
        public string OperationName { get; private set; }
        private double sum;
        public double Sum
        {
            get
            {
                return sum;
            }
            set
            {
                sum = value;
                NotifyOfPropertyChange(() => Sum);
            }
        }
        private BindableCollection<ElementaryOperation> listOfOperation;
        public BindableCollection<ElementaryOperation> ListOfOperation
        {
            get

            {
                return listOfOperation;
            }
            set
            {
                listOfOperation = value;
                NotifyOfPropertyChange(() => ListOfOperation);
                sum = sumAll();
            }
        } 
        private double sumAll()
        {
            double temp = 0;
            foreach (var item in ListOfOperation)
            {
                temp += item.AvgTime;
            }
            return temp;
        }
        public Operation(string name)
        {
            OperationName = name;
            ListOfOperation = new BindableCollection<ElementaryOperation>();
        }
    }
}
