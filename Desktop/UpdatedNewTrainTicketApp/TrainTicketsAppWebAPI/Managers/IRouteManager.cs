using DomainLibrary.Interfaces;

namespace TrainTicketsAppWebAPI.Managers
{
    public interface IRouteManager : IDisposable
    {
        IRouteRepository Routes { get; set; }

        int Complete();
        
    }
}