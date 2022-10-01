using DomainLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TrainTicketsAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TrainController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<DomainLibrary.Entities.Train>>> GetTrains()
        {

            _unitOfWork.Trains.GetAll();
            _unitOfWork.Complete();
            return Ok();


        }

        [HttpPost]

        public async Task<ActionResult<List<DomainLibrary.Entities.Train>>> AddTrain(DomainLibrary.Entities.Train train)
        {
            _unitOfWork.Trains.Add(train);
            _unitOfWork.Complete();
            return Ok();
        }




    }
}
