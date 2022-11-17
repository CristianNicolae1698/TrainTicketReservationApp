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
        [Route("Register")]
        public async Task<ActionResult<List<Client>>> Register([FromBody] ClientDto newClient)
        {
            var client=_mapper.Map<Client>(newClient);
            _clientManager.CreateClient(client);
            return Ok();
        }

        

        [HttpPost]
        [Route("SignIn")]

        public async Task<ActionResult<string>> SignIn([FromBody] ClientDto newClient)
        {
            var client = _mapper.Map<Client>(newClient);
            var id = _clientManager.GetCLientIdByNameDto(client);
            return Ok(id);
        }














    }
}
