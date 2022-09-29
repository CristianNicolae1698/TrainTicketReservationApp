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

        



        [HttpGet]
        public async Task<ActionResult<List<DomainLibrary.Entities.Route>>> GetRoutes()
        {
            var routes = new List<DomainLibrary.Entities.Route>
            {
                new DomainLibrary.Entities.Route
                {
                    RouteName="Sebes-Cluj",
                    StationOrder=99
                }
            };
            return Ok(routes);
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
