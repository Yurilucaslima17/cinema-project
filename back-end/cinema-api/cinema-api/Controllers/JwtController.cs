using cinema_api.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinema_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        [HttpGet]
        public IActionResult Jwt()
        {
            return new ObjectResult(JwtToken.GenerateJwtToken());
        }
    }
}
