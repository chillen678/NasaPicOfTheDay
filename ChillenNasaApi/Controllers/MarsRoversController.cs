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
        public IActionResult RefreshCameras(string Cameraname, string roverName, string type, string _queryEarthDate, string _querySol, string page = "")
        {
            return ViewComponent("RoverCameras", new { Cameraname=  Cameraname, roverName = roverName, type = type, queryEarthDate = _queryEarthDate, querySol= _querySol, page= page  });
        }

    }
}
