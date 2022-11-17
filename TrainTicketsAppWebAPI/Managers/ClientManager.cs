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

        

        public void CreateClient(Client client)
        {
           
            
                _clientRepository.PostClientIfNotExist(client);
            
           
        }

       

        public Guid GetCLientIdByNameDto(Client client)
        {
            return _clientRepository.GetCLientIdByNameDto(client);
        }

        
        
    }
}
