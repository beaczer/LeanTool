namespace Lean.Classes
{
    public interface IBalansData
    {
       CycleAnalyse CycleAnalys { get; set; }
       int Id { get; set; }
       string Name { get; set; }
       double AVGTime { get; set; }
       int OperatorNumber { get; set; }
       int Order { get; set; } 
    }
}