using ChillenNasaApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChillenNasaApi.Controllers
{
    public class MarsRoversController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetManifest(string _roverName, string _queryType = "", string _queryEarthDate = "", string _querySol = "")
        {
            return ViewComponent("MissionManifest", new { roverName = _roverName, QueryType = _queryType, QueryEarthDate = _queryEarthDate, QuerySol = _querySol });
        }


        [HttpGet]
        public IActionResult RefreshCameras(List<cameras> cams)
        {
            return ViewComponent("RoverCameras", new {  });
        }

    }
}
