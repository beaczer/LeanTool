using Caliburn.Micro;

namespace Lean.Classes
{
    public interface IOperation
    {
         BindableCollection<ElementaryOperation> ListOfOperation { get; set; }
         BindableCollection<CycleAnalyse> CycleAnalyses { get; set; }
         BindableCollection<FilmCycleCollection> FCycleCollection { get; set; }
         double WaitingTime { get; set; }
         double AVTime { get; set; }
         double ControlTime { get; set; }
         double TransportTime { get; set; }

    }
}