using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VUEAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeniRedirectController : ControllerBase
    {        
        private readonly ILogger<WeatherForecastController> _logger;

        public BeniRedirectController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            return Redirect("~/WinOt");
        }
    }
}
