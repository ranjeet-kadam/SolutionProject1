using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EChallan1.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyFirstApiController : ControllerBase
    {
        
        [HttpGet]
        public ActionResult Index()
        {
            return Ok(new string[] { "Hello", "Ranjeet" });
        }

    }
}

