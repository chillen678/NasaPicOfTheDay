using ChillenNasaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace ChillenNasaApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _Configure;
        private readonly string apiBaseUrl;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _Configure = configuration;
            apiBaseUrl = _Configure.GetValue<string>("TheNasaKey");
        }
        
        public async Task<IActionResult> Index(AstronomyPictureOfTheDaySearch search)
        {
            AtronomyPictureOfTheDayList AstronomyDayList = new AtronomyPictureOfTheDayList();
            IFormatProvider culture = new CultureInfo("en-US", true);
            string endpoint = apiBaseUrl;
            Boolean singleDate = false;

            AstronomyDayList.apdList = new List<AstronomyPictureoftheDay>();
            if (search == null || search.startDate == null)
            {
                singleDate = true;
                endpoint += "&date=" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "&thumbs=true";
                search.startDate = DateTime.ParseExact(DateTime.Now.Date.ToString("yyyy-MM-dd"), "yyyy-MM-dd", culture); ;
                AstronomyDayList.searchParamaters = search;
            }
            else if (search == null || search.endDate == null)
            {
                singleDate = true;
                endpoint += "&date=" + search.startDate.Value.ToString("yyyy-MM-dd")+ "&thumbs=true";
                search.startDate = DateTime.ParseExact(search.startDate.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", culture);
                AstronomyDayList.searchParamaters = search;
            }
            else
            {
                endpoint += "&start_date=" + search.startDate.Value.ToString("yyyy-MM-dd");
                AstronomyPictureOfTheDaySearch newSearch = new AstronomyPictureOfTheDaySearch();             
                newSearch.startDate = DateTime.ParseExact(search.startDate.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", culture);
                if (search.endDate != null)
                {
                    endpoint += "&end_date=" + search.endDate.Value.ToString("yyyy-MM-dd");
                    newSearch.endDate = DateTime.ParseExact(search.endDate.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", culture);
                }
                endpoint += "&thumbs=true";              
                AstronomyDayList.searchParamaters = newSearch;
            }

            using (HttpClient client = new HttpClient())
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                using (var Response = await client.GetAsync(endpoint))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = Response.Content.ReadAsStringAsync().Result;
                        if (singleDate)
                        {
                            var list = JsonConvert.DeserializeObject<AstronomyPictureoftheDay>(result);
                            AstronomyDayList.apdList.Add(list);
                            return View(AstronomyDayList);
                        }
                        else
                        {
                            var list = JsonConvert.DeserializeObject<List<AstronomyPictureoftheDay>>(result);
                            AstronomyDayList.apdList.AddRange(list);
                            return View(AstronomyDayList);
                        }
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}