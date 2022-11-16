using DomainLibrary.Entities;
using DomainLibrary.Interfaces;

namespace TrainTicketsAppWebAPI.Managers
{
    public interface IClientManager :IDisposable
    {
        IClientRepository Clients { get; set; }

        bool CreateClient(Client client);

        Guid GetCLientIdByNameDto(Client client);
    }
}
