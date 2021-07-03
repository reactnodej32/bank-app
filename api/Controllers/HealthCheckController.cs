using Microsoft.AspNetCore.Mvc;


namespace bankapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //api/healthcheck
    public class HealthCheckController : ControllerBase
    {

        [HttpGet]
        public ActionResult Get()
        {

            return StatusCode(200, "200");
        }

    }
}