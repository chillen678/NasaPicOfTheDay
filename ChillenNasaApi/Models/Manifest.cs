using ChillenNasaApi.Models.ViewComponents;

namespace ChillenNasaApi.Models
{
    public class Manifest
    {
        private photo_manifest _photo_manifest;     
      
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
    }
}
