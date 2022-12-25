using Microsoft.AspNetCore.Mvc;

namespace API_Service.Controllers
{
    [Route("api/v{version:apiVersion}/Product")]
    [ApiController]
    [ApiVersion("2.0")]
    public class ProductV2Controller : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(new List<string>()
            {
                "Kapil","Gupta","Kapil Gupta","kapil@gmail.com"
            });
        }
    }
}
