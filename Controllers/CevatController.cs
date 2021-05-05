using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    // use IIS windows authentication
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("[controller]")]
    public class CevatController : ControllerBase
    {
        public IActionResult Index()
        {
            var name = HttpContext.User.FindFirst(ClaimTypes.Name);
            return Ok(new { A = "Hosgeldin JWT kullanicisi " + name }) ;
        }        
    }
}
