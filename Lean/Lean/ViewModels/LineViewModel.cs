using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lean
{
    public class LineViewModel:Screen
    {
        

        private BindableCollection<ElementaryOperation> operation = new BindableCollection<ElementaryOperation>();
        public BindableCollection<ElementaryOperation> Operation
        {
            get
            {
                return operation;
            }
            set
            {
                operation = value;
                NotifyOfPropertyChange(() => Operation);
            }
        }
        public List<TextBlock> listTextBlock { get; set; } = new List<TextBlock>();
        public void AddOperation(object view)
        {
            listTextBlock.Add(new TextBlock());
        }
        public void AddData()
        {
            Operation.Add(new ElementaryOperation()
            {   OperationId = Operation.Count,
                OperationName = "Opis operacji",
                ElementaryOperationType = TypeOfOperation.Niezdefiniowane,
                
            });
            
        }
        public void CalculateTime(ElementaryOperation oper, string time7)
            {

            if (oper is ElementaryOperation)
            {
                int index = oper.OperationId;
                //oper.ElementaryOperationTimes[index].Time = double.Parse(time7);
                oper.MaxTime = oper.ElementaryOperationTimes.Max(x => x.Time);
                oper.MinTime = oper.ElementaryOperationTimes.Min(x => x.Time);
                oper.AvgTime = oper.ElementaryOperationTimes.Average(x => x.Time);
            }

        }
        
    }
}
