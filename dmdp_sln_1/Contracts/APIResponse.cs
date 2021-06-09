using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace dmdp_sln_1.Contracts
{
    public class APIResponse<T>{
       
            public HttpStatusCode StatusCode { get; set; }
            public List<String> Errors { get; set; }
            public T EntityContainer { get; set; }
        
    }
}
