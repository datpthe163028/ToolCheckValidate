using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CheckValidate.App.DomainAllowed.Service;
using CheckValidate.Base.Controller;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace CheckValidate.App.DomainAllowed.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomainAllowedController : BaseController
    {
        private readonly IDomainAllowedService _domainAllowedService;
        
        public DomainAllowedController( IDomainAllowedService domainAllowedService )
        {
            _domainAllowedService = domainAllowedService;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(string url)
        {   
            string pattern = @"^(http|https)://([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$";

            if(!Regex.IsMatch(url, pattern, RegexOptions.IgnoreCase))
                return ResponseBadRequest(dataResponse: new { domain = "Domain invalid" });

            var list = new List<string>(await _domainAllowedService.GetList());
            if(list.Contains(url))
                return ResponseBadRequest(messageResponse: "url is already exist");
                
            if (!await _domainAllowedService.AddDomain(url))
                return ResponseNotFound();
            
            return ResponseOk(messageResponse: "Add Success");
        }
        
        [HttpGet]
        [Route("GetList")]
        public async Task<IActionResult> GetList()
        {
            string[] content = await _domainAllowedService.GetList();
            if (content == null || content.Length == 0   )
                return ResponseNotFound(messageResponse: "File empty or there is a problem reading file");

            return ResponseOk(dataResponse: content);
        }
        
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(string url)
        {
            string pattern = @"^(http|https)://([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$";
            if(!Regex.IsMatch(url, pattern, RegexOptions.IgnoreCase))
                return ResponseBadRequest(dataResponse: new { domain = "Domain invalid" });

            var status = _domainAllowedService.DeleteDomain(url).Result;

            if (status == 2)
                return ResponseNotFound(messageResponse: "domain not found");
            if(status == 3)
                return ResponseNotFound();
            if(status == 4)
                return ResponseNotFound(messageResponse: "There is a problem reading file");
            
            return ResponseOk(messageResponse: "Delete success");
        }
    }
}
