using AutoMapper;
using DomainLibrary.Entities;
using Route = DomainLibrary.Entities.Route;

namespace TrainTicketsAppWebAPI.DTOs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Route, RouteDto>();
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();
            CreateMap<Booking, BookingDto>();
        }
    }
}
