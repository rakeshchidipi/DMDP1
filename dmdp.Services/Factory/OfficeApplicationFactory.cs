using System;
using System.Collections.Generic;
using System.Text;
using dmdp.Services.Interface;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace dmdp.Services.Factory
{
    /// <summary>
    /// used to resolve office application dynamically based on user input
    /// </summary>
   public class OfficeApplicationFactory
    {
        private IOfficeApplication _officeapplication;
        private IEnumerable<IOfficeApplication> _officeapplications;
        private ILogger<OfficeApplicationFactory> _logger;
        public OfficeApplicationFactory(IEnumerable<IOfficeApplication> officeapplications, ILogger<OfficeApplicationFactory> logger)
        {
            _officeapplications = officeapplications;
            _logger = logger;
        }

        /// <summary>
        /// Resolves to office applocation
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public IOfficeApplication Resolve(string application)
        {
            try
            {
                _officeapplication= _officeapplications.FirstOrDefault(h => string.Compare( h.identifier , application,true)==0);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error_Resolve");
                throw ex;
            }
            return _officeapplication;
        }


    }
}
