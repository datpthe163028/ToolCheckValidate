using CheckValidate.App.LoudSpeaker.Model;
using CheckValidate.Base.Controller;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CheckValidate.App.LoudSpeaker.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoudController : BaseController
    {
        

        [HttpPost]
        [Route("api1")]
        public IActionResult Api1(RequestModelApi1 model)
        {
            return ResponseOk();
        }
        
        
        [HttpPost]
        [Route("api2")]
        public IActionResult Api2(RequestModelApi2 model)
        {
            return ResponseOk();
        }
        
        
        [HttpPost]
        [Route("api3")]
        public IActionResult Api3(RequestModelApi3 model)
        {
            return ResponseOk();
        }
        
        [HttpPost]
        [Route("api4")]
        public IActionResult Api4(RequestModelApi4 model)
        {
            return ResponseOk();
        }
        
        [HttpPost]
        [Route("api5")]
        public IActionResult Api5(RequestModelApi5 model)
        {
            return ResponseOk();
        }
        
        [HttpPost]
        [Route("api6")]
        public IActionResult Api6(RequestModelApi6 model)
        {
            return ResponseOk();
        }
        [HttpPost]
        [Route("api7")]
        public IActionResult Api7(RequestModelApi7 model)
        {
            return ResponseOk();
        }
        [HttpPost]
        [Route("api8")]
        public IActionResult Api8(RequestModelApi8 model)
        {
            return ResponseOk();
        }
        [HttpPost]
        [Route("api9")]
        public IActionResult Api9(RequestModelApi9 model)
        {
            return ResponseOk();
        }
    }
}
