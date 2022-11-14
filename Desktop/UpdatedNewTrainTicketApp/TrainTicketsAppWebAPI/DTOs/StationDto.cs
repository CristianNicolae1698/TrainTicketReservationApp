namespace TrainTicketsAppWebAPI.DTOs
{
    public class StationDto
    {
        public string StationName { get; set; }

        public List<Route> Routes { get; set; } = new List<Route>();


    }
}
