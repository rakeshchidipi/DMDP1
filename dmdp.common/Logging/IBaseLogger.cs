using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace dmdp.common
{
   public interface IBaseLogger
    {
        void logrequestresponse(HttpContext _context, string Request, string Response);
        void setrequestid(HttpContext _context);
    }
}
