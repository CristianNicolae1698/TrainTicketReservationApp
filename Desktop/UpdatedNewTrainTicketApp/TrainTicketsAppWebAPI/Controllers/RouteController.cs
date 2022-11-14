using AutoMapper;
using DomainLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using TrainTicketsAppWebAPI.DTOs;
using TrainTicketsAppWebAPI.Helpers;
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
        [Route("getTrainsByStationsName")]
        public async Task<ActionResult> GetTrainsByStationsName([FromBody] RouteHelper route)
        {

            List<Train> trainList = new List<Train>();
            trainList = _routeManager.Routes.GetTrainsByStationsName(route.DepartureStation, route.ArrivalStation).ToList();
            return Ok(trainList);
        }

        [HttpPost]
        [Route("getRouteIdByStationsName")]

        public async Task<ActionResult> GetRouteIdByStationsName([FromBody] RouteHelper route)
        {
            Guid id= Guid.NewGuid();
            id = _routeManager.Routes.GetRouteIdByStationsName(route.DepartureStation, route.ArrivalStation);
            return Ok(id);
        }

        //testing controller



    }
}
