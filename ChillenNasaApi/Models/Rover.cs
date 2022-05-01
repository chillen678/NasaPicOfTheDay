namespace ChillenNasaApi.Models
{
    public class Rover
    {
        public RoverType SelectRoverType { get; set; }
    }

    public enum RoverType
    {
        Curiosity, Opportunity, Spirit
    }
}
