using Microsoft.AspNetCore.Mvc;
using PushMate.TemplatingService.API.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PushMate.TemplatingService.API.Test
{
    public class TemplatingApiTest
    {
        [Fact]
        public async Task UnitTest_GetAsync()
        {
            TemplatingController controller = new TemplatingController();

            var result = await controller.Get("Hello $name$", new Dictionary<string, string> { { "name", "Denis" } });

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Hello Denis", ((OkObjectResult) result).Value);
        }

       
    }
}
