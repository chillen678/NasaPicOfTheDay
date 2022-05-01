namespace ChillenNasaApi.Models.ViewComponents
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Newtonsoft.Json;

    public class RoverCameras : ViewComponent
    {
        private readonly ILogger<MissionManifest> _logger;
        private readonly IConfiguration _Configure;
        private readonly string _justKey;
        public RoverCameras(ILogger<MissionManifest> logger, IConfiguration configuration)
        {
            _logger = logger;
            _Configure = configuration;
            _justKey = _Configure.GetValue<string>("JustKey");
        }

        public async Task<IViewComponentResult> InvokeAsync(string Cameraname, string roverName, string type, string queryEarthDate, string querySol, string page = "")
        {

            if (string.IsNullOrEmpty(Cameraname))
            {
                return View();
            }

            string BuildTheApiUrl = "https://api.nasa.gov/mars-photos/api/v1/rovers/" + roverName + "/photos?";
            if (type == "earth")
            {
                BuildTheApiUrl += "earth_date=" + queryEarthDate + "&camera=" + Cameraname;
            }
            else
            {
                BuildTheApiUrl += "sol=" + querySol + "&camera=" + Cameraname;
            }
            //if (!string.IsNullOrEmpty(page))
            //{
            BuildTheApiUrl += "&page=" + 1;
            //}
            BuildTheApiUrl += "&api_key=" + _justKey;

            MarsPhotos mp = new MarsPhotos();

            using (HttpClient client = new HttpClient())
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                using (var Response = await client.GetAsync(BuildTheApiUrl))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = Response.Content.ReadAsStringAsync().Result;
                        var list = JsonConvert.DeserializeObject<Root>(result);
                        return View(list);
                    }
                    else
                    {
                        ModelState.Clear();
                        ModelState.AddModelError(string.Empty, "Error, Please try again.");
                        return View();
                    }
                }
            }



            return View();
        }
    }
}
