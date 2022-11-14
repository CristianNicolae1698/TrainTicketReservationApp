using DomainLibrary.Entities;
using DomainLibrary.Interfaces;
using EFDataAccessLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EFDataAccessLibrary.Repositories;

using Route = DomainLibrary.Entities.Route;
using TrainTicketsAppWebAPI.Managers;
using AutoMapper;
using TrainTicketsAppWebAPI.DTOs;
using System.Configuration;

namespace TrainTicketsAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientManager _clientManager;
        private readonly IMapper _mapper;

        public ClientController(IClientManager clientManager, IMapper mapper)
        {
            _clientManager = clientManager;
            _mapper = mapper;
        }

       

        [HttpPost]
        [Route("postClientDto")]
        public async Task<ActionResult<List<Client>>> PostClientDto([FromBody] ClientDto newClient)
        {
            var client=_mapper.Map<Client>(newClient);
            _clientManager.Clients.PostClientIfNotExist(client);
            _clientManager.Complete();
            return Ok();
        }

        

        [HttpPost]
        [Route("returnClientIdDto")]

        public async Task<ActionResult<string>> ReturnClientIdDto([FromBody] ClientDto newClient)
        {
            var client = _mapper.Map<Client>(newClient);
            Guid id = Guid.NewGuid();
            id = _clientManager.Clients.GetCLientIdByNameDto(client);
            return Ok(id);
        }














    }
}
