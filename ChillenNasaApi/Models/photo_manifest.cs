namespace ChillenNasaApi.Models.ViewComponents
{
    public class photo_manifest
    {

        //{"name":"Curiosity","landing_date":"2012-08-06","launch_date":"2011-11-26","status":"active","max_sol":3459,"max_date":"2022-04-30","total_photos":566206,

        private string _name;
        private DateTime? _landing_date;
        private DateTime? _launch_date;
        private string _status;
        private string _max_sol;
        private DateTime? _max_date;
        private string _total_photos;
        private List<Photos> _photos;


        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public DateTime? landing_date
        {
            get
            {
                return _landing_date;
            }
            set
            {
                _landing_date = value;
            }
        }

        public DateTime? launch_date
        {
            get
            {
                return _launch_date;
            }
            set
            {
                _launch_date = value;
            }
        }
        public string status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        public string max_sol
        {
            get
            {
                return _max_sol;
            }
            set
            {
                _max_sol = value;
            }
        }
        public DateTime? max_date
        {
            get
            {
                return _max_date;
            }
            set
            {
                _max_date = value;
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

        public List<Photos> photos
        {
            get
            {
                return _photos;
            }
            set
            {
                _photos = value;
            }
        }
    }
}
