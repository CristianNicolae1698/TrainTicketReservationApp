using DomainLibrary.Entities;
using DomainLibrary.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrainTicketsAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public RouteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public IActionResult GetPopularRoutes([FromQuery] int count)
        {
            var popularRoutes = _unitOfWork.Routes.GetPopularRoutes(count);
            return Ok(popularRoutes);
        }

        [HttpPost]
        public void Post([FromBody] string routeName)
        {
            var route = new DomainLibrary.Entities.Route
            {
                RouteName = routeName,
               
            };
            //var station = new Station
            //{
            //    StationName="Bucuresti",
            //};
            _unitOfWork.Routes.Add(route);
           // _unitOfWork.Stations.Add(station);
            _unitOfWork.Complete();
            
        } 

    }
}
