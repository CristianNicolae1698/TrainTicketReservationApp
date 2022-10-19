using DomainLibrary.Entities;
using DomainLibrary.Interfaces;
using EFDataAccessLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EFDataAccessLibrary.Repositories;

using Route = DomainLibrary.Entities.Route;

namespace TrainTicketsAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public IndexController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }






        //[HttpGet]
        [Route("getAllRoutes")]

        public async Task<ActionResult> GetAllRoutes()
        {

            return Ok(_unitOfWork.Routes.GetAll());

        }


        [HttpGet]

        public async Task<ActionResult> GetRouteIdByStations([FromQuery] string arrivalStation, string departureStation)
        {
            string routeName = $"{arrivalStation} - {departureStation}";
            List<Train> trainList = new List<Train>();
            trainList = _unitOfWork.Routes.GetTrainsByRouteName(routeName).ToList();
            return Ok(trainList);



        }
        
        [HttpGet]
        [Route("getRouteByName")]
        public async Task<ActionResult> GetRouteIdByStations([FromBody] string routeName)
        {

            var route = _unitOfWork.Routes.GetRouteByName(routeName);


            return Ok(route);



        }
        [HttpGet]
        [Route("getStationsByRouteName")]
        public async Task<ActionResult> GetStationsByRouteName([FromBody]string routeName)
        {
            List<Station> stationList=new List<Station>();
            stationList=_unitOfWork.Routes.GetStationsByRouteName(routeName).ToList();
            return Ok(stationList);
        }


        //this method we'll be using in the first request

        [HttpPost]
        [Route("getTrainsByRouteName")]
        public async Task<ActionResult> GetTrainsByRouteName([FromBody] string routeName)
        {
            
            List<Train> trainList = new List<Train>();
            trainList = _unitOfWork.Routes.GetTrainsByRouteName(routeName).ToList();
            return Ok(trainList);
        }



        [HttpPost]
        public async Task<ActionResult<List<DomainLibrary.Entities.Route>>> AddRoute(DomainLibrary.Entities.Route route)
        {

            _unitOfWork.Routes.Add(route);
            _unitOfWork.Complete();
            return Ok();
        }






    }
}
