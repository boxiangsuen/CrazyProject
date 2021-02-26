using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace swaggerDemo.Controllers
{
    [Route("api/swagger")]
    [ApiController]
    public class HomeController : Controller
    {
        [HttpPost("GetXX")]
        public String GetXX() {
            return "Hello World!";
        }

        [HttpPost("GetNum")]
        public Int32 GetNum() {
            return 1;
        }

        [HttpPost("GetVoid")]
        public void GetVoid() { 
        
        }
    }
}
