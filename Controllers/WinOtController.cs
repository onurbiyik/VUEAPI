using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace VUEAPI.Controllers
{

    // use IIS authentication
    [Authorize(AuthenticationSchemes = IISDefaults.AuthenticationScheme)]    

    [ApiController]
    [Route("[controller]")]
    public class WinOtController : ControllerBase
    {
        public IActionResult Index()
        {
            var name = HttpContext.User.FindFirst(ClaimTypes.Name);
            return Ok(new { A = "Hosgeldin IIS kullanicisi " + User.Identity.Name + " JWT CLAIM " + name });
        }
    }
}
