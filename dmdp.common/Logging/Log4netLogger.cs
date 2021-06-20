using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using log4net;

namespace dmdp.common
{
    public class Log4netLogger : IBaseLogger
    {
        //private  HttpContext _context;
        private Stopwatch _stopwatch;

        public Log4netLogger()
        {
            // _context = context.HttpContext;
            _stopwatch = new Stopwatch();
            _stopwatch.Start();

        }

        public void logrequestresponse(HttpContext _context, string Request, string Response)
        {
            var AccessLogger = LogManager.GetLogger(Assembly.GetAssembly(typeof(Log4netLogger)), "AccessLog");
            var ForensicLogger = LogManager.GetLogger(Assembly.GetAssembly(typeof(Log4netLogger)), "ForensicLog");
            try
            {
                _stopwatch.Stop();

                string mid = string.Empty;
                //string Response = string.Empty;
                //string Request = string.Empty;
                string timetaken = _stopwatch.ElapsedMilliseconds.ToString();
                string responseCode = string.Empty;

                mid = Guid.NewGuid().ToString();
                // Response =await FormatResponse(_context.Response);
                // Request =await _context.Request.GetRawBodyStringAsync();
                responseCode = "1004";

                log4net.LogicalThreadContext.Properties["requestId"] = _context.Request.Headers["requestId"].ToString();
                log4net.LogicalThreadContext.Properties["forwardedFor"] = _context.Request.HttpContext.Connection.RemoteIpAddress.ToString();
                log4net.LogicalThreadContext.Properties["merchantId"] = mid;
                log4net.LogicalThreadContext.Properties["currentRequestUrl"] = _context.Request.HttpContext.Request.Path + _context.Request.HttpContext.Request.QueryString.Value;
                log4net.LogicalThreadContext.Properties["timeTaken"] = timetaken;
                log4net.LogicalThreadContext.Properties["status"] = _context.Response.StatusCode;
                log4net.LogicalThreadContext.Properties["contentLength"] = _context.Request.ContentLength;
                log4net.LogicalThreadContext.Properties["userAgent"] = _context.Request.Headers["User-Agent"].FirstOrDefault();
                log4net.LogicalThreadContext.Properties["request"] = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Request));
                log4net.LogicalThreadContext.Properties["response"] = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Response));
                log4net.LogicalThreadContext.Properties["accessToken"] = _context.Request.Headers["AccessToken"];
                log4net.LogicalThreadContext.Properties["responseCode"] = responseCode;
                log4net.LogicalThreadContext.Properties["method"] = _context.Request.Method;
                log4net.LogicalThreadContext.Properties["fullurl"] = string.Concat(_context.Request.Scheme, "://", _context.Request.Host, _context.Request.Path, _context.Request.QueryString);

            }
            catch (Exception ex)
            {
                AccessLogger.Error("accesslogerror-", ex);

                //throw;
            }
            finally
            {

                AccessLogger.Info(" ");
                ForensicLogger.Info(" ");
            }

        }

        public void setrequestid(HttpContext _context)
        {
            if (!_context.Request.Headers.ContainsKey("requestId"))
            {
                _context.Request.Headers["requestId"] = Guid.NewGuid().ToString();
                log4net.LogicalThreadContext.Properties["requestId"] = _context.Request.Headers["requestId"].ToString();
            }
        }
    }
}
