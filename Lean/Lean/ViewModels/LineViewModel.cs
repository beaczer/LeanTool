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
        private BindableCollection<ElementaryOperation> myCollection = new BindableCollection<ElementaryOperation>();
        public BindableCollection<ElementaryOperation> MyCollection
        {
            get
            {
                return myCollection;
            }
            set
            {
                myCollection = value;
                NotifyOfPropertyChange(() => MyCollection);
            }
        }
        public List<TextBlock> listTextBlock { get; set; } = new List<TextBlock>();
        public void AddOperation(object view)
        {
            listTextBlock.Add(new TextBlock());
        }
        public void AddData()
        {
            MyCollection.Add(new ElementaryOperation()
            {   OperationId = MyCollection.Count + 1,
                OperationName = "Opis operacji",
                ElementaryOperationType = TypeOfOperation.Niezdefiniowane,
                
            });
            
        }
        public void TextChange(object dc)
        {

        }
    }
}
