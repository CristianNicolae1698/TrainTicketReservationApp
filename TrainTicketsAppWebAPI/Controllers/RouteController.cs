using AutoMapper;
using DomainLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using TrainTicketsAppWebAPI.DTOs;
using TrainTicketsAppWebAPI.Managers;
using Route = DomainLibrary.Entities.Route;

namespace TrainTicketsAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {

        private readonly IRouteManager _routeManager;
        private readonly IMapper _mapper;

        

        public RouteController(IRouteManager routeManager, IMapper mapper)
        {
            _routeManager = routeManager;
            _mapper = mapper;
        }

        
        [HttpPost]
        [Route("getTrainsByStations")]
        public async Task<ActionResult> GetTrainsByStations([FromBody] RouteStationDto route)
        {

            
            return Ok(_routeManager.GetTrainsByRoute(route.ArrivalStation, route.DepartureStation));
        }

        [HttpPost]
        [Route("getRouteIdByStations")]

        public async Task<ActionResult> GetRouteIdByStations([FromBody] RouteStationDto route)
        {
            Guid routeId = new Guid();
            routeId = _routeManager.GetRouteIdByStations(route.DepartureStation, route.ArrivalStation);
            return Ok(routeId);
        }



    }
}
