using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dmdp_sln_1.Contracts;
using dmdp.Services.Factory;
using Microsoft.Extensions.Logging;

namespace dmdp_sln_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]  // to Authenticate and authorise
    public class OfficeApplicationController : ControllerBase
    {
        private OfficeApplicationFactory _officefactory;
        private ILogger<OfficeApplicationController> _logger;
        public OfficeApplicationController( OfficeApplicationFactory officefactory,ILogger<OfficeApplicationController> logger)
        {
            officefactory = _officefactory;
            _logger = logger;
        }

        [HttpPost]
        [Route("Refresh/{identifier}/{chartid}")]
        public async Task<APIResponse<string>> Refresh(string identifier, int chartid) {
            APIResponse<string> response =new APIResponse<string>();
            response.EntityContainer = await _officefactory.Resolve(identifier).RefreshData(chartid);
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }


    }
}
