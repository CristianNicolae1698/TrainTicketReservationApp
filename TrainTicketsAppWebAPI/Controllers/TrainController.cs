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
        [HttpGet]
        [Route("getTrainsByRouteName")]
        public async Task<ActionResult<List<DomainLibrary.Entities.Train>>> GetTrainsByRouteName([FromBody] string routeName)
        {


            var trainList=new List<DomainLibrary.Entities.Train>();
            trainList = _unitOfWork.Trains.GetTrainsByRouteName(routeName).ToList();
            return Ok(trainList);

           

        }

        [HttpGet]
        [Route("getFirstTrainByRouteName")]
        public async Task<ActionResult<List<DomainLibrary.Entities.Train>>> GetFirstTrain([FromBody] string routeName)
        {


            var train = _unitOfWork.Trains.GetFirstTrainFromRouteName(routeName);
            
            return Ok(train);



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
