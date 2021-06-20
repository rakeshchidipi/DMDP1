using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dmdp.common
{
    [ApiController]
    public class AppErrorController : ControllerBase
    {
        private ILogger _logger;
        public AppErrorController(ILogger<AppErrorController> logger)
        {
            _logger = logger;
        }
        [Route("Error/500")]
        public IActionResult Error()
        {
            var exceptionhandlerpathfeatures = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            // exceptionhandlerpathfeatures.Error.StackTrace
            Exception ex = exceptionhandlerpathfeatures.Error;
            string requestid = HttpContext.Request.Headers["requestId"].ToString();
            _logger.LogError(ex, "Application_level_Error_Start-");
            _logger.LogError("AppError End");
            string errorinfo = "Sorry, seems some internal exception RequestID :" + requestid;
            return new JsonResult(errorinfo);
        }

    }
}
