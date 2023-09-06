using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CheckValidate.Base.Controller
{
    public class BaseController : ControllerBase
    {
        protected IActionResult ResponseOk(dynamic dataResponse = null, string messageResponse = null, bool overrideBody = true)
        {
            return StatusCode((int)HttpStatusCode.OK, overrideBody ? new { data = dataResponse, message = messageResponse, statusCode = (int)HttpStatusCode.OK } : dataResponse);
        }

        protected IActionResult ResponseBadRequest(dynamic dataResponse = null, string messageResponse = null, bool overrideBody = true)
        {
            return StatusCode((int)HttpStatusCode.NotFound, overrideBody ? new { data = dataResponse, message = messageResponse, statusCode = (int)HttpStatusCode.NotFound } : dataResponse);
        }

        protected IActionResult ResponseNotFound(dynamic dataResponse = null, string messageResponse = null, bool overrideBody = true)
        {
            return StatusCode((int)HttpStatusCode.NotFound, overrideBody ? new { data = dataResponse, message = messageResponse, statusCode = (int)HttpStatusCode.NotFound } : dataResponse);
        }
    }
}
