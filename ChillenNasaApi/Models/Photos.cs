namespace ChillenNasaApi.Models.ViewComponents
{
    public class Photos
    {

        //{"sol":0,"earth_date":"2012-08-06","total_photos":3702,"cameras":["CHEMCAM","FHAZ","MARDI","RHAZ"


        private string _sol;
        private DateTime? _earth_date;
        private string _total_photos;
        private List<string> _cameras;

        public string sol
        {
            get
            {
                return _sol;
            }
            set
            {
                _sol = value;
            }
        }


        public DateTime? earth_date
        {
            get
            {
                return _earth_date;
            }
            set
            {
                _earth_date = value;
            }
        }

        public string total_photos
        {
            get
            {
                return _total_photos;
            }
            set
            {
                _total_photos = value;
            }
        }

        public List<string> cameras
        {
            get
            {
                return _cameras;
            }
            set
            {
                _cameras = value;
            }
        }

    }
}
