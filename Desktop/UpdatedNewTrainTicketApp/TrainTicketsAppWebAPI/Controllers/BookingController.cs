using AutoMapper;
using DomainLibrary.Entities;
using DomainLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TrainTicketsAppWebAPI.DTOs;
using TrainTicketsAppWebAPI.Helpers;
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
        public async Task<ActionResult<List<Booking>>> PostBooking([FromBody] ClientTrainRouteHelper model)
        {
            var booking = _bookingManager.Bookings.PostBooking(model.clientId, model.trainId, model.routeId);
            
            _bookingManager.Bookings.Add(booking);
            _bookingManager.Complete();
            return Ok();
        }



        
        [HttpPost]
        [Route("displayBookingsByClientId")]

        public async Task<ActionResult<List<Booking>>> DisplayBookingsByClientId([FromBody] Guid clientId)
        {
            List<BookingDto> bookingsListDto=new List<BookingDto>();
            List<Booking> bookingsList = new List<Booking>();
            bookingsList = _mapper.Map<List<BookingDto>, List<Booking>>(bookingsListDto);
            bookingsList = _bookingManager.Bookings.DisplayBookingsByClientId(clientId).ToList();
            return Ok(bookingsList);
        }

        



    }
}
