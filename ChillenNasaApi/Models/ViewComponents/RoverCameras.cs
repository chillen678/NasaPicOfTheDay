﻿namespace ChillenNasaApi.Models.ViewComponents
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class RoverCameras : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {          
            return View();
        }
    }
}
