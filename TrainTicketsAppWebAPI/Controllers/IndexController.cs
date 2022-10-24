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



        //this method we'll be using in the first request

        [HttpPost]
        [Route("getTrainsByRouteName")]
        public async Task<ActionResult> GetTrainsByRouteName([FromBody] string routeName)
        {
            
            List<Train> trainList = new List<Train>();
            trainList = _unitOfWork.Routes.GetTrainsByRouteName(routeName).ToList();
            return Ok(trainList);
        }



        //this method we'll be using in the second request

        [HttpPost]
        [Route("postClient")]
        public async Task<ActionResult<List<DomainLibrary.Entities.Client>>> CreateClient([FromBody] Client client)
        {

            _unitOfWork.Clients.Add(client);
            _unitOfWork.Complete();
            return Ok();
        }





        public class ClientModel
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
        }

        //this method we'll be using in the third request
        [HttpPost]
        [Route("getClientId")]

        public async Task<ActionResult<string>> ReturnClientId([FromBody] ClientModel model)
        {
            Guid id = Guid.NewGuid();
            id=_unitOfWork.Clients.GetCLientIdByName(model.firstName, model.lastName);
            return Ok(id);
        }




        
        public class ClientTrainModel
        {
            public Guid clientId { get; set; }
            public Guid trainId { get; set; }
        }

        //this method we'll be using in the forth request

        [HttpPost]
        [Route("postBooking")]
        public async Task<ActionResult<List<Booking>>> CreateBooking([FromBody]ClientTrainModel model)
        {
            var booking = _unitOfWork.Bookings.CreateBooking(model.clientId, model.trainId);
            booking.Price = 47864124;
            booking.BookingDate = DateTime.Today.ToString();
            _unitOfWork.Bookings.Add(booking);
            _unitOfWork.Complete();
            return Ok();
        }





    }
}
