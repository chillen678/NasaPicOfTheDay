namespace ChillenNasaApi.Models.ViewComponents
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    public class MissionManifest: ViewComponent
    {
        private readonly ILogger<MissionManifest> _logger;
        private readonly IConfiguration _Configure;
        private readonly string apiBaseUrl;
        public MissionManifest(ILogger<MissionManifest> logger, IConfiguration configuration)
        {
            _logger = logger;
            _Configure = configuration;
            apiBaseUrl = _Configure.GetValue<string>("TheNasaManifestKey");
        }

        public async Task<IViewComponentResult> InvokeAsync(string RoverName = "", string QueryType = "", string QueryEarthDate = "", string QuerySol = "")
        {
            if (!string.IsNullOrEmpty(RoverName))
            {
                string endpoint = apiBaseUrl.Replace("Curiosity", RoverName);
                IFormatProvider culture = new CultureInfo("en-US", true);
                using (HttpClient client = new HttpClient())
                {
                    //List<MissionManifest> mm = new List<MissionManifest>();
                    //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                    using (var Response = await client.GetAsync(endpoint))
                    {
                        if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var result = Response.Content.ReadAsStringAsync().Result;
                            var mm = JsonConvert.DeserializeObject<Manifest>(result);


                            if(!string.IsNullOrEmpty(QueryType) && QueryType == "earth")
                            {
                            
                                var d = DateTime.ParseExact(QueryEarthDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                                mm.choosenDateInfo = mm.photo_manifest.photos.Where(x => x.earth_date.Value.ToString("yyyy-MM-dd") == d.ToString("yyyy-MM-dd")).ToList();
                            }
                            else if(!string.IsNullOrEmpty(QueryType) && QueryType == "mars")
                            {
                                mm.choosenDateInfo = mm.photo_manifest.photos.Where(x => x.sol == QuerySol).ToList();
                            }
                            else
                            {

                            }
                            return View(mm);
                        }
                        else
                        {
                            ModelState.Clear();
                            ModelState.AddModelError(string.Empty, "Error, Please try again.");
                            return View();
                        }
                    }
                }
            }
            else
            {
                return View();
            }
        }
    }
}
