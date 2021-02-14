using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeadPageController : ControllerBase
    {
        [HttpGet]
        public string SayHello()
        {
            return "It's a nice day to rent a car!";
        }       
    }
}