using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VUEAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WhoAmIController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok(new { A = "you are " + this.User.Identity.Name }) ;
        }
    }
}
