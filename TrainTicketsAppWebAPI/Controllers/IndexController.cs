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

        



        [HttpGet]
        [Route("{id:guid}")]

        public async Task<ActionResult> GetRouteById([FromRoute]Guid id)
        {
            var route = _unitOfWork.Routes.GetById(id);

            if (route == null)
            {
                return NotFound();
            }
            return Ok(route);

        }
        [HttpGet]
        public async Task<ActionResult> GetAllRoutes()
        {
            
            return Ok(_unitOfWork.Routes.GetAll());

        }

        [HttpGet]
        public async Task<ActionResult> GetRouteByIdBody([FromBody] Guid id)
        {
            var route = _unitOfWork.Routes.GetById(id);

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
