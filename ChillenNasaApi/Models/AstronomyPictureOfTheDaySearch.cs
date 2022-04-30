namespace ChillenNasaApi.Models
{
    public class AstronomyPictureOfTheDaySearch
    {

        private DateTime? _startDate;
        private DateTime? _endDate;

        public DateTime? startDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
            }
        }
        public DateTime? endDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
            }
        }

    }
}
