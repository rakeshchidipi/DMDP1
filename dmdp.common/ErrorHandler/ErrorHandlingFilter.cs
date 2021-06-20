﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;



namespace dmdp.common
{
    public class ErrorHandlingFilter : ExceptionFilterAttribute
    {
        private ILogger _logger;
        public ErrorHandlingFilter(ILogger<ErrorHandlingFilter> logger)
        {
            _logger = logger;
        }
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            string requestid = context.HttpContext.Request.Headers["requestId"].ToString();
            _logger.LogError(exception, "Error_in_controlleraction_Start-");
            string errorinfo = "Sorry, seems some internal exception RequestID :" + requestid;

            context.HttpContext.Response.StatusCode = 500;
            context.ExceptionHandled = true; //optional 
            context.Result = new JsonResult(errorinfo);
            base.OnException(context);
        }

    }
}
