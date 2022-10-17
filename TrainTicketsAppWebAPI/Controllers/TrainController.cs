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


            return Ok(_unitOfWork.Trains.GetAll());


        }
        //[HttpGet]
        //public async Task<ActionResult<List<DomainLibrary.Entities.Train>>> GetTrainsByRouteName([FromBody] string routeName)
        //{

            
            

        //    return Ok(_unitOfWork.Trains.GetTrainsByRouteName(routeName));
           

        //}

        [HttpPost]

        public async Task<ActionResult<List<DomainLibrary.Entities.Train>>> AddTrain(DomainLibrary.Entities.Train train)
        {
            _unitOfWork.Trains.Add(train);
            _unitOfWork.Complete();
            return Ok();
        }




    }
}
