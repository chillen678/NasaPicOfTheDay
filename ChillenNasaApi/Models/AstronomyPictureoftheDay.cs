namespace ChillenNasaApi.Models
{
    public class AstronomyPictureoftheDay
    {
        private string _copyright = "";
        private string _date = "";
        private string _explanation = "";
        private string _hdurl = "";
        private string _media_type = "";
        private string _service_version = "";
        private string _title = "";
        private string _url = "";
        private string _thumbnail_url = "";

        // Declare a Code property of type string:
        public string thumbnail_url
        {
            get
            {
                return _thumbnail_url;
            }
            set
            {
                _thumbnail_url = value;
            }
        }
        public string date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }

        public string explanation
        {
            get
            {
                return _explanation;
            }
            set
            {
                _explanation = value;
            }
        }

        public string hdurl
        {
            get
            {
                return _hdurl;
            }
            set
            {
                _hdurl = value;
            }
        }

        public string media_type
        {
            get
            {
                return _media_type;
            }
            set
            {
                _media_type = value;
            }
        }

        public string service_version
        {
            get
            {
                return _service_version;
            }
            set
            {
                _service_version = value;
            }
        }

        public string title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        public string url
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
            }
        }
    }
}
