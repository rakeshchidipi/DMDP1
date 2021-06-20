using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dmdp_sln_1.Contracts;
using dmdp.Services.Factory;
using Microsoft.Extensions.Logging;
using dmdp.common;


namespace dmdp_sln_1.Controllers
{
    [ServiceFilter(typeof(ErrorHandlingFilter))]
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]  // to Authenticate and authorise
    public class OfficeApplicationController : ControllerBase
    {
        private OfficeApplicationFactory _officefactory;
        private ILogger<OfficeApplicationController> _logger;
        public OfficeApplicationController( OfficeApplicationFactory officefactory,ILogger<OfficeApplicationController> logger)
        {
            _officefactory = officefactory;
            _logger = logger;
        }

        [HttpGet]
        [Route("Refresh/{identifier}/{chartid}")]
        public async Task<APIResponse<string>> Refresh(string identifier, int chartid) {
            APIResponse<string> response =new APIResponse<string>();
            response.EntityContainer = await _officefactory.Resolve(identifier).RefreshData(chartid);
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }

        [HttpGet("Health")]
        public int Health()
        {
            try
            {
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }


    }
}
