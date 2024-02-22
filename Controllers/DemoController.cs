using ASP.NET_tut.MyLogging;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_tut.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]

    public class DemoController : ControllerBase
    {
        public readonly ILogger<DemoController> _myLogger;

        public DemoController(ILogger<DemoController>logger){
            _myLogger=logger;
        }

        [HttpGet]
        public ActionResult Index(){
             
            _myLogger.LogTrace("Log message from trace method");            
            _myLogger.LogDebug("Log message from LogDebug method");            
            _myLogger.LogInformation("Log message from LogInformation method");            
            _myLogger.LogWarning("Log message from LogWarning method");            
            _myLogger.LogError("Log message from LogError method");            
            _myLogger.LogCritical("Log message from LogCritical method");            
            return Ok();
        }
    }
}