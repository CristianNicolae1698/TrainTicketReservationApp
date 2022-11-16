using AutoMapper;
using DomainLibrary.Entities;
using DomainLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TrainTicketsAppWebAPI.DTOs;
using TrainTicketsAppWebAPI.Managers;

namespace TrainTicketsAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingManager _bookingManager;
        private readonly IMapper _mapper;
        public BookingController(IBookingManager bookingManager, IMapper mapper)
        {
            _bookingManager = bookingManager;
            _mapper = mapper;
        }

        

        //this method we'll be using in the forth request

        [HttpPost]
        [Route("postBooking")]
        public async Task<ActionResult<List<Booking>>> PostBooking([FromBody] ClientTrainRouteDto model)
        {

            return Ok(_bookingManager.CreateBooking(model.clientId, model.trainId, model.routeId)); 
        }



        
        [HttpPost]
        [Route("displayBookings")]

        public async Task<ActionResult<List<Booking>>> DisplayBookings([FromBody] Guid clientId)
        {
            List<BookingDto> bookingsListDto=new List<BookingDto>();
            List<Booking> bookingsList = new List<Booking>();
            bookingsList = _mapper.Map<List<BookingDto>, List<Booking>>(bookingsListDto);
            bookingsList = _bookingManager.DisplayBookings(clientId).ToList();
            return Ok(bookingsList);
        }

        



    }
}
