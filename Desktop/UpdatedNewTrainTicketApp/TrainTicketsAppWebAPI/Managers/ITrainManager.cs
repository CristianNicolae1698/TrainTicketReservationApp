using DomainLibrary.Interfaces;

namespace TrainTicketsAppWebAPI.Managers
{
    public interface ITrainManager :IDisposable
    {
        ITrainRepository Routes { get; set; }

        int Complete();
       
    }
}