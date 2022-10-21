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
        [Route("postRoute")]
        public async Task<ActionResult<List<DomainLibrary.Entities.Route>>> AddRoute(DomainLibrary.Entities.Route route)
        {

            _unitOfWork.Routes.Add(route);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpPost]
        [Route("postClient")]
        public async Task<ActionResult<List<DomainLibrary.Entities.Client>>> CreateClient(DomainLibrary.Entities.Client client)
        {

            _unitOfWork.Clients.Add(client);
            _unitOfWork.Complete();
            return Ok();
        }


        [HttpGet]
        [Route("getClientId")]

        public async Task<ActionResult<string>> ReturnClientId([FromQuery] string firstName, string lastName)
        {
            Guid id = Guid.NewGuid();
            id=_unitOfWork.Routes.GetCLientIdByName(firstName, lastName);
            return Ok(id);
        }

        
        public class MyModel
        {
            public Guid clientId { get; set; }
            public Guid trainId { get; set; }
        }
        
        public class ComplexModel
        {
            public Client client { get; set; }
            public Train train { get; set; }
        }

        [HttpPost]
        [Route("postComplexBooking")]
        public async Task<ActionResult<List<Booking>>> CreateBooking([FromBody] ComplexModel complexModel)
        {
            var booking1 = new Booking()
            {
                BookingDate = DateTime.Today.ToString(),
                Price = 11111

            };
            booking1 = _unitOfWork.Routes.AddClientAndTrainToBooking(complexModel.client, complexModel.train);
            _unitOfWork.Bookings.Add(booking1);
            _unitOfWork.Complete();
            return Ok();
        }




        [HttpPost]
        [Route("postBooking")]
        public async Task<ActionResult<List<Booking>>> CreateBooking([FromBody]MyModel model)
        {
            var booking = _unitOfWork.Routes.CreateBooking(model.clientId, model.trainId);
            booking.Price = 47864124;
            booking.BookingDate = DateTime.Today.ToString();
            _unitOfWork.Bookings.Add(booking);
            _unitOfWork.Complete();
            return Ok();
        }





    }
}
