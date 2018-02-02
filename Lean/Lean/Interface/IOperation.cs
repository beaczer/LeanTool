using Caliburn.Micro;

namespace Lean.Classes
{
    public interface IOperation
    {
         BindableCollection<ElementaryOperation> ListOfOperation { get; set; }
    }
}