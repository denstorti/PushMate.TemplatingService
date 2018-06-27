using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PushMate.TemplatingService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplatingController : ControllerBase
    {
        // GET: api/Templating
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string templateText,[FromQuery] Dictionary<string, string> parameters)
        {
            if (String.IsNullOrEmpty(templateText))
            {
                return BadRequest("Query string templateText cannot be null or empty");
            }

            parameters.Remove("templateText");

            string result = await TemplateService.ApplyTextTemplateAsync(templateText, parameters);

            return Ok(result);
        }
        
    }
}
