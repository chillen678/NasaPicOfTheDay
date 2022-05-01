using ChillenNasaApi.Models.ViewComponents;

namespace ChillenNasaApi.Models
{
    public class Manifest
    {
        private photo_manifest _photo_manifest;
        private List<Photos> _choosenDateInfo;
        public photo_manifest photo_manifest
        {
            get
            {
                return _photo_manifest;
            }
            set
            {
                _photo_manifest = value;
            }
        }

        

        public List<Photos> choosenDateInfo
        {
            get
            {
                return _choosenDateInfo;
            }
            set
            {
                _choosenDateInfo = value;
            }
        }
    }
}
