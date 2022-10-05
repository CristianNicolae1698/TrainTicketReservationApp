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
        //public async Task<ActionResult> GetAllRoutes()
        //{

        //    return Ok(_unitOfWork.Routes.GetAll());

        //}



        




        [HttpGet]

        public async Task<ActionResult> GetRouteIdByStations([FromQuery] string arrivalStation, string departureStation)
        {
            string RouteName = $"{arrivalStation} - {departureStation}";
            var route = _unitOfWork.Routes.GetById(_unitOfWork.Routes.GetRouteIdByName(RouteName));

            if (route == null)
            {
                return NotFound();
            }
            return Ok(route);

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
