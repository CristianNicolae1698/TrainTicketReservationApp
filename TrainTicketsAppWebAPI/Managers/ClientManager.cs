using DomainLibrary.Interfaces;
using DomainLibrary.Entities;

namespace TrainTicketsAppWebAPI.Managers
{
    public class ClientManager: IClientManager
    {
        private readonly IClientRepository _clientRepository;
        public ClientManager(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
            
        }
        
        public IClientRepository Clients { get; set; }

        public int Complete()
        {
            throw new NotImplementedException();
        }

        public bool CreateClient(Client client)
        {
            try
            {
                _clientRepository.PostClientIfNotExist(client);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Guid GetCLientIdByNameDto(Client client)
        {
            return _clientRepository.GetCLientIdByNameDto(client);
        }
    }
}
