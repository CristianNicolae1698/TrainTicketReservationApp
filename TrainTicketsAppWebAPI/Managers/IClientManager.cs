using DomainLibrary.Entities;
using DomainLibrary.Interfaces;

namespace TrainTicketsAppWebAPI.Managers
{
    public interface IClientManager 
    {
        IClientRepository Clients { get; set; }

        void CreateClient(Client client);

        Guid GetCLientIdByNameDto(Client client);

    }
}
