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
        public IActionResult GetManifest(string _roverName)
        {
            return ViewComponent("MissionManifest", new { roverName = _roverName });
        }

        


    }
}
