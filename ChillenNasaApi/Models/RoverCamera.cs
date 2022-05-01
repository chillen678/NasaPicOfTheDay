namespace ChillenNasaApi.Models
{

    public class RoverCamera
    {
        public RoverType SelectRoverType { get; set; }
    }

    public enum RoverCameraType
    {
        FHAZ, RHAZ, MAST, CHEMCAM, MAHLI, MARDI, NAVCAM, PANCAM, MINITES 
    }

}
