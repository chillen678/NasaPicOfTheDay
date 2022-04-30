namespace ChillenNasaApi.Models
{
    public class AtronomyPictureOfTheDayList
    {
        List<AstronomyPictureoftheDay> _apdList;
        AstronomyPictureOfTheDaySearch _searchParamaters = new AstronomyPictureOfTheDaySearch();

        public List<AstronomyPictureoftheDay>? apdList
        {
            get
            {
                return _apdList;
            }
            set
            {
                _apdList = value;
            }
        }

        public AstronomyPictureOfTheDaySearch searchParamaters
        {
            get
            {
                return _searchParamaters;
            }
            set
            {
                _searchParamaters = value;
            }
        }
    }
}
