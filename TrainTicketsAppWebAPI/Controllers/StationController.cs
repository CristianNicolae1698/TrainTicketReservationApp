using DomainLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DomainLibrary.Entities;

namespace TrainTicketsAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public StationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]

        public async Task<ActionResult<List<Station>>> GetStations()
        {
            var stations = new List<Station>
            {
                new Station
                {
                    StationName ="Caracal",

                }
            };
            return Ok(stations);
        }

        [HttpPost]
        public async Task<ActionResult<Station>> AddStation(Station station)
        {
            _unitOfWork.Stations.Add(station);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
