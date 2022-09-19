using Microsoft.AspNetCore.Mvc;
using DomainLibrary.Interfaces;

namespace TrainTicketsAppWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]



    public class RoutesController : ControllerBase
    {
        private readonly ILogger<RoutesController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public RoutesController(ILogger<RoutesController> logger, IUnitOfWork unitOfWork)
        {

            _logger = logger;
            _unitOfWork=unitOfWork;

        }

        [HttpPost]

        public async Task<IActionResult> CreateRoute (DomainLibrary.Entities.Route route)
        {
            if (ModelState.IsValid)
            {
                route.Id = Guid.NewGuid();
                await _unitOfWork.Routes.Add(route);
                await _unitOfWork.CompleteAsync();

                return CreatedAtAction("GetItem", new {route.Id}, route);

            }

            return new JsonResult("Something went wrong") { StatusCode = 500};

        }



    }
}
