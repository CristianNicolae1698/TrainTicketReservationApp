namespace TrainTicketsAppWebAPI.DTOs
{
    public class ClientTrainRouteDto
    {
        public Guid clientId { get; set; }
        public Guid trainId { get; set; }

        public Guid routeId { get; set; }

    }
}
