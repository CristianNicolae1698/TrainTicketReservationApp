using DomainLibrary.Interfaces;

namespace TrainTicketsAppWebAPI.Managers
{
    public interface IClientManager :IDisposable
    {
        IClientRepository Clients { get; set; }
        int Complete();

    }
}
